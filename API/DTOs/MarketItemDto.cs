namespace API.DTOs
{
    public class MarketItemDto
    {
        public int Id { get; set; }
        public string ItemType { get; set; } // "Animal", "Land", "Supply"
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public bool IsSold { get; set; }
        public DateTime? SoldAt { get; set; }
        public int SellerFarmerId { get; set; }
    }
}