namespace API.DTOs
{
    public class PaymentSchemeDto
    {
        public int Id { get; set; }
        public string LandType { get; set; } = null!;
        public decimal AmountPerHectare { get; set; }
    }
}
