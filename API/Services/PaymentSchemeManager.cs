using API.ApplicationDBContext;
using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Services
{
    public class PaymentSchemeManager
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly IMapper _mapper;

        public PaymentSchemeManager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = config.CreateMapper();
        }

        public List<PaymentSchemeDto> GetAll()
        {
            var schemes = _context.PaymentSchemes.ToList();
            return _mapper.Map<List<PaymentSchemeDto>>(schemes);
        }

        public PaymentSchemeDto? GetById(int id)
        {
            var scheme = _context.PaymentSchemes.FirstOrDefault(p => p.Id == id);
            return scheme == null ? null : _mapper.Map<PaymentSchemeDto>(scheme);
        }

        public void Create(PaymentSchemeDto dto)
        {
            var scheme = _mapper.Map<PaymentScheme>(dto);
            _context.PaymentSchemes.Add(scheme);
            _context.SaveChanges();
        }

        public bool Update(int id, PaymentSchemeDto dto)
        {
            var scheme = _context.PaymentSchemes.FirstOrDefault(p => p.Id == id);
            if (scheme == null) return false;

            scheme.LandType = dto.LandType;
            scheme.AmountPerHectare = dto.AmountPerHectare;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var scheme = _context.PaymentSchemes.FirstOrDefault(p => p.Id == id);
            if (scheme == null) return false;

            _context.PaymentSchemes.Remove(scheme);
            _context.SaveChanges();
            return true;
        }
    }
}
