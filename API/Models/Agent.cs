using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Agent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public string Name { get; set; }
        public int AgencyId { get; set; }
        [ForeignKey("AgencyId")]
        public Agency Agency { get; set; }

        public List<Farmer> Farmers { get; set; }
    }
}
