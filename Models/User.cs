using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Models
{
    public class Users
    {
        [Key]
        public int Id {get;set;}

        [Required]
        [MaxLength(16)]
        public required string UserName {get;set;}

        [Required]
        [MinLength(6)]
        public required string PasswordHash {get;set;}

        [Required]
        [EmailAddress]
        public required string Email {get; set;}

        
        public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
        
    }
}