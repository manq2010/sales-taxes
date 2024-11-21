using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalesTaxesApi.Models
{
    /// <summary>
    /// Represents a Product in the system.
    /// </summary>
    [Table("Product")]
    public class Product
    {
        /// <summary>
        /// Gets or sets the ID of the product.
        /// </summary>
        [Key]
        public int productId { get; set; }
        [Required]
        public string productName { get; set; }
        [Range(0.00, 9999999.99)]
        public decimal unitPrice { get; set; }
        public bool? isImport { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime deleted_at { get; set; }
    }
}
