using API.DTOs;
using API.Models;
using API.ApplicationDBContext;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class FarmerRatingManager
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly IMapper _mapper;

        public FarmerRatingManager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();
        }

        public List<FarmerRatingDto> GetAllRatings()
        {
            var ratings = _context.FarmerRatings
                .Include(r => r.Farmer)
                .ToList();

            return _mapper.Map<List<FarmerRatingDto>>(ratings);
        }

        public FarmerRatingDto GetRatingById(int ratingId)
        {
            var rating = _context.FarmerRatings
                .Include(r => r.Farmer)
                .FirstOrDefault(r => r.Id == ratingId);

            if (rating == null)
                throw new Exception("Rating not found");

            return _mapper.Map<FarmerRatingDto>(rating);
        }

        public void AddRating(FarmerRatingDto ratingDto)
        {
            var rating = _mapper.Map<FarmerRating>(ratingDto);
            _context.FarmerRatings.Add(rating);
            _context.SaveChanges();
        }

        public void UpdateRating(FarmerRatingDto ratingDto)
        {
            var rating = _context.FarmerRatings.FirstOrDefault(r => r.Id == ratingDto.Id);
            if (rating != null)
            {
                _mapper.Map(ratingDto, rating);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Rating not found");
            }
        }

        public void RemoveRating(int ratingId)
        {
            var rating = _context.FarmerRatings.FirstOrDefault(r => r.Id == ratingId);
            if (rating != null)
            {
                _context.FarmerRatings.Remove(rating);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Rating not found");
            }
        }
    }
}
