using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class FarmerSupply
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int FarmerId { get; set; }
        [ForeignKey("FarmerId")]
        public Farmer Farmer { get; set; }

        public int SupplyId { get; set; }
        [ForeignKey("SupplyId")]
        public Supply Supply { get; set; }

        public int Quantity { get; set; } 
    }
}
