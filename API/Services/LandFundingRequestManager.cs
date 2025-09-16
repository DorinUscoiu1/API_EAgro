using API.ApplicationDBContext;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class LandFundingRequestManager
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly IMapper _mapper;

        public LandFundingRequestManager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();
        }
        public List<LandFundingRequestDto> GetAllRequests()
        {

            var requests = _context.LandFundingRequests.ToList();
            return _mapper.Map<List<LandFundingRequestDto>>(requests);
        }
        public LandFundingRequest CreateRequest(int farmerId, List<int> landIds)
        {
            var lands = _context.Lands.Where(l => landIds.Contains(l.Id)).ToList();

            if (lands.Count != landIds.Count)
                throw new Exception("One or more lands not found.");

            var request = new LandFundingRequest
            {
                FarmerId = farmerId,
                Lands = lands,
                Status = "pending"
            };

            _context.LandFundingRequests.Add(request);
            _context.SaveChanges();

            return request;
        }

        public List<LandDto> GetLandsByRequestId(int requestId)
        {
            var request = _context.LandFundingRequests
                .Include(r => r.Lands)
                .FirstOrDefault(r => r.Id == requestId);

            if (request == null)
                throw new Exception("Request not found.");

            return _mapper.Map<List<LandDto>>(request.Lands);
        }

        public void UpdateStatus(int requestId, string status, string comment)
        {
            var request = _context.LandFundingRequests.Include(r => r.Lands)
                .FirstOrDefault(r => r.Id == requestId);

            if (request == null)
                throw new Exception("Request not found.");

            request.Status = status;
            request.AgentComment = comment;

            if (request.Status == "Accepted")
            {
                var farmer = _context.Farmers.FirstOrDefault(f => f.Id == request.FarmerId);
                if (farmer == null)
                    throw new Exception("Farmer not found.");

                decimal totalAmount = 0;
                foreach (var land in request.Lands)
                {
                    var scheme = _context.PaymentSchemes.FirstOrDefault(p => p.LandType == land.Type);
                    //if (scheme == null)
                    //    throw new Exception($"Nu exista schema de plata pentru tipul terenului: {land.Type}");

                    if(scheme!=null) totalAmount += scheme.AmountPerHectare * (decimal) land.Area;
                }
                farmer.Budget += totalAmount;
            }

            _context.SaveChanges();
        }

        public void DeleteRequest(int requestId)
        {
            var request = _context.LandFundingRequests
                .Include(r => r.Farmer)
                .Include(r => r.Lands)
                .FirstOrDefault(r => r.Id == requestId);

            if (request == null)
                throw new Exception("Cererea nu a fost găsită.");

            request.Lands.Clear();

            if (request.Farmer.LandFundingRequest?.Id == request.Id)
            {
                request.Farmer.LandFundingRequest = null;
            }

            _context.LandFundingRequests.Remove(request);
            _context.SaveChanges();
        }


    }
}
