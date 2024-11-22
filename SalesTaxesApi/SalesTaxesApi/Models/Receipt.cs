using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalesTaxesApi.Models
{
    /// <summary>
    /// Represents a Receipt in the system.
    /// </summary>
    [Table("Receipt")]
    public class Receipt
    {
        /// <summary>
        /// Gets or sets the ID of the Receipt.
        /// </summary>
        [Key]
        public int receiptId { get; set; }
        [Required]
        [Range(0.00, 9999999.99)]
        public decimal totalTaxes { get; set; }
        [Range(0.00, 9999999.99)]
        public decimal totalCost { get; set; }
        public string receiptName { get; set; }
        public string aspUserId { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime deleted_at { get; set; }
        public virtual List<ReceiptItem> ReceiptItems { get; set; } = new List<ReceiptItem>();
    }
}
