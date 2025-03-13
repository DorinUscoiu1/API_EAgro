using API.ApplicationDBContext;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using API.DTOs;
using API.Models;

namespace API.Services
{
    public class FarmerManager
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly IMapper _mapper;

        public FarmerManager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();
        }

        public List<FarmerDto> GetAllFarmers()
        {
            var farmers = _context.Farmers.ToList();
            return _mapper.Map<List<FarmerDto>>(farmers);
        }
        public FarmerDto GetFarmer(int farmerId)
        {
            var farmer = _context.Farmers.FirstOrDefault(f => f.Id == farmerId);
            return _mapper.Map<FarmerDto>(farmer);
        }

        public void AddFarmer(FarmerDto farmer)
        {
            var newFarmer = _mapper.Map<Farmer>(farmer);
            _context.Farmers.Add(newFarmer);
            _context.SaveChanges();
        }
        public void RemoveFarmer(int farmerId)
        {
            var farmer = _context.Farmers.FirstOrDefault(a => a.Id == farmerId);
            if (farmer != null)
            {
                _context.Farmers.Remove(farmer);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Farmer not found");
            }
        }
        public void UpdateFarmer(FarmerDto farmer)
        {
            var far = _context.Farmers.FirstOrDefault(f => f.Id == farmer.Id);
            if (far == null) throw new Exception("Farmer does not exist!");

            _mapper.Map(farmer, far);
            _context.SaveChanges();
        }
        public List<LandDto> GetFarmerLands(int farmerId)
        {
            var farmer = _context.Farmers
                .Include(f => f.Lands) // Include terenurile
                .FirstOrDefault(f => f.Id == farmerId);

            if (farmer == null)
            {
                throw new Exception("Farmer not found!");
            }

            return _mapper.Map<List<LandDto>>(farmer.Lands);
        }
        public List<AnimalDto> GetFarmerAnimals(int farmerId)
        {
            var farmer = _context.Farmers
                .Include(f => f.Animals) // Include animalele
                .FirstOrDefault(f => f.Id == farmerId);

            if (farmer == null)
            {
                throw new Exception("Farmer not found!");
            }

            return _mapper.Map<List<AnimalDto>>(farmer.Animals);
        }

    }
}
