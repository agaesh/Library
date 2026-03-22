using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public enum UserType
    {
        Admin = 0,
        Librarian = 1,
        User = 2,
        Member = 3
    }

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        public string HashingPassword { get; set; } = string.Empty;

        public UserType Type { get; set; }
    }
}
