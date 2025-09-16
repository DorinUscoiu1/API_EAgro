namespace API.DTOs
{
    public class LandFundingRequestDto
    {
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public string AgentComment { get; set; }
    }
}
