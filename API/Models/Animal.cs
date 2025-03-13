using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Breed { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }

        // Adăugăm relația cu Farmer
        public int FarmerId { get; set; }
        [ForeignKey("FarmerId")]
        public Farmer Farmer { get; set; }
        public List<Supply> Supplies { get; set; } = new();
    }
}
