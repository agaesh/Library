using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Library.Models
{
    public class Borrows
    {
        [Key]
        public int Id { get; set; }

        // Foreign Keys
        [Required]
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int MemberId { get; set; }
        public User? User { get; set; }


        // Dates
        [Required]
        public DateTime BorrowDate { get; set; }

        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        // Status & Extra
        [Required]
        public bool IsReturned { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal FineAmount { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int CreateById { get; set; }

        [JsonIgnore]   
        public User? CreateBy { get; set; }
    }


}