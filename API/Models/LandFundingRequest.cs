using API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class LandFundingRequest
{
    [Key]
    public int Id { get; set; }

    public int FarmerId { get; set; }
    [ForeignKey("FarmerId")]
    public Farmer Farmer { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Status { get; set; } = "Pending"; 

    public string? AgentComment { get; set; }

    public List<Land> Lands { get; set; } = new();
}
