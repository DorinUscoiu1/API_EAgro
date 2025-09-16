using API.ApplicationDBContext;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;

public class MarketItemManager
{
    private readonly ApplicationDbContext _context = new ApplicationDbContext();
    private readonly IMapper _mapper;

    public MarketItemManager()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        _mapper = config.CreateMapper();
    }

    public List<MarketItemDto> GetAllMarketItems()
    {
        var items = _context.MarketItems
            .ToList();
        return _mapper.Map<List<MarketItemDto>>(items);
    }

    public List<MarketItemDto> GetMarketItemsByFarmer(int farmerId)
    {
        var items = _context.MarketItems
            .Where(m => m.SellerFarmerId == farmerId)
            .ToList();
        return _mapper.Map<List<MarketItemDto>>(items);
    }

    public void AddMarketItem(MarketItemDto dto)
    {
        var marketItem = _mapper.Map<MarketItem>(dto);
        marketItem.IsSold = false;
        marketItem.SoldAt = null;
        _context.MarketItems.Add(marketItem);
        _context.SaveChanges();
    }
    public MarketItemDto? GetMarketItemById(int id)
    {
        var item = _context.MarketItems.FirstOrDefault(m => m.Id == id);
        return item == null ? null : _mapper.Map<MarketItemDto>(item);
    }

    public void MarkItemAsSoldToBuyer(int id, int buyerFarmerId)
    {
        var item = _context.MarketItems.FirstOrDefault(m => m.Id == id);
        if (item == null) throw new Exception("Item not found");

        if (item.IsSold)
            throw new Exception("Item is already sold");
        var buyer = _context.Farmers.FirstOrDefault(f => f.Id == buyerFarmerId);
        var seller = _context.Farmers.FirstOrDefault(f => f.Id == item.SellerFarmerId);
        if (buyer == null)
            throw new Exception("buyer not found");

        if (seller == null)
            throw new Exception("seller not found");
        if (buyer == seller)
            throw new Exception("you can't buy your own market item");

        if ((buyer.Budget<item.Price))
        {
            throw new Exception("Your budget is too low");
        }

        item.IsSold = true;
        item.SoldAt = DateTime.UtcNow;
        item.BuyerFarmerId = buyerFarmerId;
        if (item.ItemType == "Animal")
        {
            var animal = _context.Animals.FirstOrDefault(a => a.Id == item.ItemId);
            if (animal == null) throw new Exception("Animal not found");
            animal.FarmerId = buyerFarmerId;
        }
        else if (item.ItemType == "Land")
        {
            var land = _context.Lands.FirstOrDefault(l => l.Id == item.ItemId);
            if (land == null) throw new Exception("Land not found");
            land.FarmerId = buyerFarmerId;
        }

        if(buyer!=null)buyer.Budget -= item.Price;
        if(seller!=null)seller.Budget += item.Price;
        _context.SaveChanges();
    }

    public void MarkItemAsSold(int id)
    {
        var item = _context.MarketItems.FirstOrDefault(m => m.Id == id);
        if (item == null) throw new Exception("Item not found");

        item.IsSold = true;
        item.SoldAt = DateTime.UtcNow;

        _context.SaveChanges();
    }

    public void DeleteMarketItem(int id)
    {
        var item = _context.MarketItems.FirstOrDefault(m => m.Id == id);
        if (item == null) throw new Exception("Item not found");

        _context.MarketItems.Remove(item);
        _context.SaveChanges();
    }
}
