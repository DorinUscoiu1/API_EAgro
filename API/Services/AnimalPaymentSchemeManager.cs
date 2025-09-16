using API.ApplicationDBContext;
using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Services
{
    public class AnimalPaymentSchemeManager
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly IMapper _mapper;

        public AnimalPaymentSchemeManager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = config.CreateMapper();
        }

        public List<AnimalPaymentSchemeDto> GetAll()
        {
            var schemes = _context.AnimalPaymentSchemes.ToList();
            return _mapper.Map<List<AnimalPaymentSchemeDto>>(schemes);
        }

        public AnimalPaymentSchemeDto? GetById(int id)
        {
            var scheme = _context.AnimalPaymentSchemes.FirstOrDefault(p => p.Id == id);
            return scheme == null ? null : _mapper.Map<AnimalPaymentSchemeDto>(scheme);
        }

        public void Create(AnimalPaymentSchemeDto dto)
        {
            var scheme = _mapper.Map<AnimalPaymentScheme>(dto);
            _context.AnimalPaymentSchemes.Add(scheme);
            _context.SaveChanges();
        }

        public bool Update(int id, AnimalPaymentSchemeDto dto)
        {
            var scheme = _context.AnimalPaymentSchemes.FirstOrDefault(p => p.Id == id);
            if (scheme == null) return false;

            scheme.Type = dto.Type;
            scheme.AmountPerHead = dto.AmountPerHead;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var scheme = _context.AnimalPaymentSchemes.FirstOrDefault(p => p.Id == id);
            if (scheme == null) return false;

            _context.AnimalPaymentSchemes.Remove(scheme);
            _context.SaveChanges();
            return true;
        }
    }
}
