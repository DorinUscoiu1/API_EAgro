using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class MarketItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ItemType { get; set; }
        public int ItemId { get; set; }
        public decimal Price { get; set; }
        public bool IsSold { get; set; } = false;
        public DateTime? SoldAt { get; set; }

        public int? SellerFarmerId { get; set; }
        [ForeignKey("SellerFarmerId")]
        public Farmer SellerFarmer { get; set; }
        public int? BuyerFarmerId { get; set; } 
        [ForeignKey("BuyerFarmerId")]
        public Farmer BuyerFarmer { get; set; }

    }
}