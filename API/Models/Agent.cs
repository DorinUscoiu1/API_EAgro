using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Agent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int AgencyId { get; set; }
        [ForeignKey("AgencyId")]
        public Agency Agency { get; set; }
        public List<Farmer> Farmers { get; set; }
    }

}
