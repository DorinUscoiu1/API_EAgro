using API.ApplicationDBContext;
using AutoMapper;
using API.DTOs;
using API.Models;
namespace API.Services
{
    public class LandManager
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly IMapper _mapper;

        public LandManager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            _mapper = config.CreateMapper();
        }
        public List<LandDto> GetAllLands()
        {
            var lands = _context.Lands.ToList();
            return _mapper.Map<List<LandDto>>(lands);
        }
        public LandDto GetLand(int landId)
        {
            var land = _context.Lands.FirstOrDefault(a => a.Id == landId);
            return _mapper.Map<LandDto>(land);
        }
        public void AddLand(LandDto landDto)
        {
            var land = _mapper.Map<Land>(landDto);
            _context.Lands.Add(land);
            _context.SaveChanges();
        }
        public void UpdateLand(LandDto landDto)
        {
            var land = _context.Lands.FirstOrDefault(a => a.Id == landDto.Id);
            if (land != null)
            {
                _mapper.Map(landDto, land);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Land not found");
            }
        }
        public bool IsLandBoughtByCurrentOwner(int landId, int currentFarmerId)
        {
            var item = _context.MarketItems
                .FirstOrDefault(i =>
                    i.ItemType == "Land" &&
                    i.ItemId == landId &&
                    i.IsSold &&
                    i.BuyerFarmerId == currentFarmerId);

            return item != null;
        }

        public void RemoveLand(int landId)
        {
            var land = _context.Lands.FirstOrDefault(a => a.Id == landId);
            
            if (land != null)
            {
                var marketItem = _context.MarketItems
            .FirstOrDefault(m => m.ItemType == "Land" && m.ItemId == landId);

                if (marketItem != null)
                {
                    _context.MarketItems.Remove(marketItem);
                }
                _context.Lands.Remove(land);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Land not found");
            }
        }


    }
}
