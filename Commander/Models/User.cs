using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }

    }
}