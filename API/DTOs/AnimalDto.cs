using API.Models;

namespace API.DTOs
{
    public class AnimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }
        public int FarmerId { get; set; }
    }
}
