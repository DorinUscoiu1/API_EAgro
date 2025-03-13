using API.DTOs;
using API.Models;
using API.ApplicationDBContext;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class SupplyManager
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly IMapper _mapper;

        public SupplyManager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();
        }


        public List<SupplyDto> GetAllSupplies()
        {
            var supplies = _context.Supplies.ToList();
            return _mapper.Map<List<SupplyDto>>(supplies);
        }

        public SupplyDto GetSupply(int supplyId)
        {
            var supply = _context.Supplies.FirstOrDefault(s => s.Id == supplyId);
            if (supply == null)
            {
                throw new Exception("Supply not found");
            }
            return _mapper.Map<SupplyDto>(supply);
        }

        public void AddSupply(SupplyDto supplyDto)
        {
            var supply = _mapper.Map<Supply>(supplyDto);
            _context.Supplies.Add(supply);
            _context.SaveChanges();
        }

        public void UpdateSupply(SupplyDto supplyDto)
        {
            var supply = _context.Supplies.FirstOrDefault(s => s.Id == supplyDto.Id);
            if (supply == null)
            {
                throw new Exception("Supply not found");
            }

            _mapper.Map(supplyDto, supply);
            _context.SaveChanges();
        }

        public void DeleteSupply(int supplyId)
        {
            var supply = _context.Supplies.FirstOrDefault(s => s.Id == supplyId);
            if (supply == null)
            {
                throw new Exception("Supply not found");
            }

            _context.Supplies.Remove(supply);
            _context.SaveChanges();
        }
    }
}
