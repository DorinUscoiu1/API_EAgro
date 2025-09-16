namespace API.DTOs
{
    public class AgentDto
    {
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public string Name { get; set; }
        public int AgencyId { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
