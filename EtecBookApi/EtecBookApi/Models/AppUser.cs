using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EtecBookApi.Models
{
    [Table("users")]
    public class AppUser
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(60)]
        public string? Name { get; set; } 

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string? UserName { get; set; } 

        [Required]
        public string? Password { get; set; } 
        public string Token {get; set;}

        [Required]
        [StringLength(20)]
        public string Role { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set;}

        [Required]
        public string ProfilePicture { get; set; }
    }
}