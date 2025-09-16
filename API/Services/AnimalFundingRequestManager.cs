using API.ApplicationDBContext;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AnimalFundingRequestManager
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly IMapper _mapper;

        public AnimalFundingRequestManager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();
        }
        public List<AnimalFundingRequestDto> GetAllRequests()
        {

            var requests = _context.AnimalFundingRequests.ToList();
            return _mapper.Map<List<AnimalFundingRequestDto>>(requests);
        }
        public AnimalFundingRequest CreateRequest(int farmerId, List<int> animalIds)
        {
            var animals = _context.Animals.Where(l => animalIds.Contains(l.Id)).ToList();

            if (animals.Count != animalIds.Count)
                throw new Exception("One or more lands not found.");

            var request = new AnimalFundingRequest
            {
                FarmerId = farmerId,
                Animals = animals,
                Status = "pending"
            };

            _context.AnimalFundingRequests.Add(request);
            _context.SaveChanges();

            return request;
        }

        public List<AnimalDto> GetLandsByRequestId(int requestId)
        {
            var request = _context.AnimalFundingRequests
                .Include(r => r.Animals)
                .FirstOrDefault(r => r.Id == requestId);

            if (request == null)
                throw new Exception("Request not found.");

            return _mapper.Map<List<AnimalDto>>(request.Animals);
        }

        public void UpdateStatus(int requestId, string status, string comment)
        {
            var request = _context.AnimalFundingRequests.Include(r => r.Animals)
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
                foreach (var animal in request.Animals)
                {
                    var scheme = _context.AnimalPaymentSchemes.FirstOrDefault(p => p.Type == animal.Name);
                    //if (scheme == null)
                    //    throw new Exception($"Nu există schemă de plată pentru tipul terenului: {land.Type}");

                    if (scheme != null) totalAmount += scheme.AmountPerHead;
                }
                farmer.Budget += totalAmount;
            }

            _context.SaveChanges();
        }

        public void DeleteRequest(int requestId)
        {
            var request = _context.AnimalFundingRequests
                .Include(r => r.Farmer)
                .Include(r => r.Animals)
                .FirstOrDefault(r => r.Id == requestId);

            if (request == null)
                throw new Exception("Cererea nu a fost găsită.");

            request.Animals.Clear();
            
            if (request.Farmer.AnimalFundingRequest?.Id == request.Id)
            {
                request.Farmer.AnimalFundingRequest = null;
            }

            _context.AnimalFundingRequests.Remove(request);
            _context.SaveChanges();
        }

    }
}
