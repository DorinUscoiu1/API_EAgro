using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.Models
{
    public class Farmer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Budget { get; set; }
        public string Category { get; set; }
        public int AgentId { get; set; }
        [ForeignKey("AgentId")]
        public Agent Agent { get; set; }

        public List<Land> Lands { get; set; }
        public List<Animal> Animals { get; set; }

        public List<FarmerRating> FarmersRatings { get; set; }

        public List<MarketItem> MarketSales { get; set; } = new();
    }

}
