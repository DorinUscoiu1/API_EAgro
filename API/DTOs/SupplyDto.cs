namespace API.DTOs
{
    public class SupplyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Quality { get; set; }
        public decimal Price { get; set; }
        public int AnimalId { get; set; }
    }
}
