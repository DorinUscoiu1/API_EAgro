using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string? Phone {  get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }  

        public Agent Agent { get; set; }
        public Farmer Farmer { get; set; }
    }
}
