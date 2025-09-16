namespace API.DTOs
{
    public class FarmerSupplyDto
    {
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public int SupplyId { get; set; }
        public int Quantity { get; set; }
    }
}
