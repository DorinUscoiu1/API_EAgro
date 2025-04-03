namespace API.DTOs
{
    public class FarmerDto
    {
        public int Id { get; set; } // ID-ul Farmerului
        public int UserId { get; set; } // ID-ul Userului asociat
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Budget { get; set; }
        public string Category { get; set; }
        public int AgentId { get; set; }
        public string Email { get; set; } // Adăugat pentru a accesa datele Userului
    }
}
