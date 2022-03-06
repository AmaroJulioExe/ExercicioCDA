using System.ComponentModel.DataAnnotations;

namespace ExercicioCDA.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
