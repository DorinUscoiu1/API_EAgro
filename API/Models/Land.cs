using Microsoft.AspNetCore.Components.Routing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.Models
{
    public class Land
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string County { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public double Area { get; set; }

        public int FarmerId { get; set; }
        [ForeignKey("FarmerId")]
        public Farmer Farmer { get; set; }
        public string CoordinatesJson { get; set; }
    }

}
