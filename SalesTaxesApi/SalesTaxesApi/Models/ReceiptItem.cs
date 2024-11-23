using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalesTaxesApi.Models
{
    /// <summary>
    /// Represents a Receipt Item in the system.
    /// </summary>
    [Table("ReceiptItem")]
    public class ReceiptItem
    {
        /// <summary>
        /// Gets or sets the ID of the Receipt Item.
        /// </summary>
        [Key]
        public int receiptItemId { get; set; }
        public int receiptId { get; set; }
        public string itemName { get; set; }
        public string productTypeName { get; set; }
        public bool? isExempted { get; set; }
        public bool? isImported { get; set; }
        [Range(1, 99999999)]
        public decimal quantity { get; set; }
        [Range(0.00, 999999999.99)]
        public decimal taxAmount { get; set; }
        [Range(0.00, 999999999.99)]
        public decimal priceIncludingTax { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime deleted_at { get; set; }
    }
}
