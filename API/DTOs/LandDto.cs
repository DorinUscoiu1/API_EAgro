namespace API.DTOs
{
    public class LandDto
    {
        public int Id { get; set; }
        public string County { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public double Area { get; set; }
        public int FarmerId { get; set; }
        public string CoordinatesJson { get; set; }
    }
}
