namespace API.DTOs
{
    public class FarmerDto
    {
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public decimal Budget { get; set; }
        public string Category { get; set; }
        public int AgentId { get; set; }
        public string Email { get; set; }
    }
}
