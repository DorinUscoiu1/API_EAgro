namespace API.DTOs
{
    public class FarmerRatingDto
    {
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
