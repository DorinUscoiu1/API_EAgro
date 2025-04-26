using API.ApplicationDBContext;
using API.DTOs;
using API.Models;
using AutoMapper;

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
