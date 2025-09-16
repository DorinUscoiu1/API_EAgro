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

        private readonly SupplyManager supplyManager;
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
            var farmers = _context.Farmers.Include(a => a.User).ToList();
            return _mapper.Map<List<FarmerDto>>(farmers);
        }
        public FarmerDto GetFarmer(int farmerId)
        {
            var farmer = _context.Farmers.Include(a => a.User).FirstOrDefault(f => f.Id == farmerId);
            return _mapper.Map<FarmerDto>(farmer);
        }

        public void AddFarmer(FarmerDto farmer)
        {
            var newFarmer = _mapper.Map<Farmer>(farmer);
            var user = new User
            {
                Name = farmer.Name,
                Email = farmer.Email,
                Password = "51bf5502a7102c96f3ffb54d6d8762c0077dd473aa673701e233e4f3f989a149",
                Phone = farmer.Phone,
                Role = "Farmer"
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            newFarmer.UserId = user.Id;
            _context.Farmers.Add(newFarmer);
            _context.SaveChanges();
        }
        public void RemoveFarmer(int farmerId)
        {
            var farmer = _context.Farmers.FirstOrDefault(f => f.Id == farmerId);
            //if (farmer != null)
            //{
            //    var user = _context.Users.FirstOrDefault(f=>f.Id==farmer.UserId);
            //    if (user != null)
            //    {
            //        _context.Users.Remove(user);
            //    }

            //    _context.SaveChanges();
            //}
            if (farmer == null)
            {
                throw new Exception("Farmer not found");
            }

            var marketItems = _context.MarketItems
                .Where(mi => mi.BuyerFarmerId == farmerId || mi.SellerFarmerId == farmerId)
                .ToList();

            foreach (var item in marketItems)
            {
                if (item.BuyerFarmerId == farmerId)
                {
                    bool ownsLand = item.ItemId != null &&
                                    _context.Lands.Any(l => l.Id == item.ItemId && l.FarmerId == farmerId);

                    bool ownsAnimal = item.ItemId != null &&
                                     _context.Animals.Any(a => a.Id == item.ItemId && a.FarmerId == farmerId);

                    if (ownsLand || ownsAnimal)
                    {
                        _context.MarketItems.Remove(item);
                        continue;
                    }

                    item.BuyerFarmerId = null;
                }

                if (item.SellerFarmerId == farmerId)
                {
                    bool stillOwnsLand = item.ItemId != null &&
                                        _context.Lands.Any(l => l.Id == item.ItemId && l.FarmerId == farmerId);

                    bool stillOwnsAnimal = item.ItemId != null &&
                                          _context.Animals.Any(a => a.Id == item.ItemId && a.FarmerId == farmerId);

                    if (stillOwnsLand || stillOwnsAnimal)
                    {
                        _context.MarketItems.Remove(item);
                        continue;
                    }

                    item.SellerFarmerId = null;
                }
            }
            var user = _context.Users.FirstOrDefault(f => f.Id == farmer.UserId);


            _context.SaveChanges();
            _context.Farmers.Remove(farmer);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();

                _context.SaveChanges();
            }
        }


        public void UpdateFarmer(FarmerDto farmer)
        {
            var far = _context.Farmers.FirstOrDefault(f => f.Id == farmer.Id);
            if (far == null) throw new Exception("Farmer does not exist!");

            _mapper.Map(farmer, far);
            _context.SaveChanges();
        }
        public List<LandDto> GetFarmerLandsFiltered(int farmerId, string location, string county, string type)
        {
            var farmer = _context.Farmers
                .Include(f => f.Lands)
                .FirstOrDefault(f => f.Id == farmerId);

            if (farmer == null)
            {
                throw new Exception("Farmer not found!");
            }
            decimal totalArea = 0;
            foreach (Land land in farmer.Lands)
            {
                totalArea += (decimal)land.Area;
            }
            if (totalArea > 50)
                farmer.Category = "Mare";
            _context.SaveChanges();
            var lands = farmer.Lands.AsQueryable();
            if (!string.IsNullOrEmpty(location))
                lands = lands.Where(l => l.Location.Contains(location));
            if (!string.IsNullOrEmpty(county))
                lands = lands.Where(l => l.County.Contains(county));
            if (!string.IsNullOrEmpty(type))
                lands = lands.Where(l => l.Type.Contains(type));

            return _mapper.Map<List<LandDto>>(lands.ToList());
        }
        public List<LandDto> GetOtherFarmerLands(int farmerId)
        {
            var otherFarmers = _context.Farmers
                .Include(f => f.Lands)
                .Where(f => f.Id != farmerId)
                .ToList();

            var otherLands = otherFarmers.SelectMany(f => f.Lands).ToList();

            return _mapper.Map<List<LandDto>>(otherLands);
        }

        public List<FarmerRatingDto> GetFarmerRatings(int farmerId) 
        {
            var farmer = _context.Farmers.Include(f=>f.FarmersRatings).FirstOrDefault(f=>f.Id == farmerId);
            if(farmer == null)
            { throw new Exception("Farmer not found!");}
            return _mapper.Map<List<FarmerRatingDto>>(farmer.FarmersRatings);
        }
        public List<AnimalDto> GetFarmerAnimals(int farmerId)
        {
            var farmer = _context.Farmers
                .Include(f => f.Animals)
                .FirstOrDefault(f => f.Id == farmerId);

            if (farmer == null)
            {
                throw new Exception("Farmer not found!");
            }

            return _mapper.Map<List<AnimalDto>>(farmer.Animals);
        }
        public List<MarketItemDto> GetMarketListingsByFarmer(int farmerId)
        {
            var items = _context.MarketItems.Where(m => m.SellerFarmerId == farmerId).ToList();
            if (items == null)
            {
                throw new Exception("Farmer not found!");
            }
            return _mapper.Map<List<MarketItemDto>>(items);
        }
        public FarmerDto GetFarmerByUserId(int userId)
        {
            var farmer = _context.Farmers.Include(f => f.User).FirstOrDefault(f => f.UserId == userId);
            if (farmer == null)
                return null;
            return _mapper.Map<FarmerDto>(farmer);
        }
        public LandFundingRequestDto? GetFundingRequestByFarmerId(int farmerId)
        {
            var farmer = _context.Farmers
                .Include(f => f.LandFundingRequest)
                .FirstOrDefault(f => f.Id == farmerId);

            if (farmer == null)
                throw new Exception("Farmer not found!");

            if (farmer.LandFundingRequest == null)
                return null;

            return _mapper.Map<LandFundingRequestDto>(farmer.LandFundingRequest);
        }
        public AnimalFundingRequestDto? GetAnimalFundingRequestByFarmerId(int farmerId)
        {
            var farmer = _context.Farmers
                .Include(f => f.AnimalFundingRequest)
                .FirstOrDefault(f => f.Id == farmerId);

            if (farmer == null)
                throw new Exception("Farmer not found!");

            if (farmer.AnimalFundingRequest == null)
                return null;

            return _mapper.Map<AnimalFundingRequestDto>(farmer.AnimalFundingRequest);
        }
        public List<FarmerSupplyDto> GetFarmerSupplies(int farmerId)
        {
            var supplies = _context.FarmerSupplies
                .Include(fs => fs.Supply)
                .Include(fs=>fs.Farmer)
                .Where(fs => fs.FarmerId == farmerId)
                .ToList();

            return _mapper.Map<List<FarmerSupplyDto>>(supplies);
        }
        public decimal GetTotalArea(int farmerId)
        {
            var farmer = _context.Farmers
               .Include(f => f.Lands)
               .FirstOrDefault(f => f.Id == farmerId);
            decimal totalArea = 0;
            if (farmer!=null)
            {
                foreach (Land land in farmer.Lands)
                {
                    totalArea += (decimal)land.Area;
                }
            }
            return totalArea;

        }
        public void BuySupply(int farmerId, int supplyId, int quantity)
        {
            var farmer = _context.Farmers
            .Include(f => f.FarmerSupplies)
            .FirstOrDefault(f => f.Id == farmerId);
            var supply = _context.Supplies
            .FirstOrDefault(f => f.Id == supplyId);

            if (supply.Quantity < quantity)
                throw new ArgumentException("Stoc insuficient.");

            var totalCost = supply.Price * quantity;
            if (farmer.Budget < totalCost)
                throw new ArgumentException("Buget insuficient.");


            var farmerSupply = _context.FarmerSupplies
                .FirstOrDefault(fs => fs.FarmerId == farmerId && fs.SupplyId == supplyId);

            if (farmerSupply == null)
            {
                farmerSupply = new FarmerSupply
                {
                    FarmerId = farmerId,
                    SupplyId = supplyId,
                    Quantity = quantity
                };
                _context.FarmerSupplies.Add(farmerSupply);
            }
            else
            {
                farmerSupply.Quantity += quantity;
            }

            supply.Quantity -= quantity;
            farmer.Budget -= totalCost;

            _context.SaveChanges();
        }

    }
}
