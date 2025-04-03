namespace API.DTOs
{
    public class AgentDto
    {
        public int Id { get; set; } // ID-ul Agentului
        public int UserId { get; set; } // ID-ul Userului asociat
        public string Name { get; set; }
        public int AgencyId { get; set; }
        public string Email { get; set; } // Adăugat pentru a accesa datele Userului
    }
}
