using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public enum DocStatus
    {
        Draft = 0,
        Posted = 1,
        Cancelled = 2
    }

    public enum DocType
    {
        GRN = 0,
        STOCKIN = 1,
        STOCKOUT = 2,
        ADJIN = 3,
        ADJOUT = 4,
        INV = 5,
        PO = 6,
        PV = 7,
    }

    public class Doc
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DocNo { get; set; } = string.Empty;

        [Required]
        public DocType DocType { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(10)]
        public string BranchCode { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Remarks { get; set; }

        [Required]
        public DocStatus Status { get; set; } = DocStatus.Draft;

        // Workflow users
        [Required]
        public int CreatedById { get; set; }
        public int? PostedById { get; set; }
        public int? ApprovedById { get; set; }

        // Navigation properties
        [ForeignKey(nameof(CreatedById))]
        public virtual User CreatedBy { get; set; }

        [ForeignKey(nameof(PostedById))]
        public virtual User? PostedBy { get; set; }

        [ForeignKey(nameof(ApprovedById))]
        public virtual User? ApprovedBy { get; set; }

        // References
        public int? RefId { get; set; }        // Link to another doc
        public int? SupplierId { get; set; }   // For GRN/vendor

    }
}