using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public required string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public required string Description { get; set; }

        [Required]
        [StringLength(150)]
        public required string Author { get; set; }

        [Required]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime Updated { get; set; } = DateTime.UtcNow;
    }
}
