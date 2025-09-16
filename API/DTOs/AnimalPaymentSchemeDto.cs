namespace API.DTOs
{
    public class AnimalPaymentSchemeDto
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public decimal AmountPerHead { get; set; }
    }
}
