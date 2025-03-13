using API.Models;

namespace API.DTOs
{
    public class AgentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AgencyId { get; set; }
    }
}
