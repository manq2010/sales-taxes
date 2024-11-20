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
        public decimal quantity { get; set; }
        public int productTypeId { get; set; }
        public decimal unitPrice { get; set; }
        public bool isImported { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public bool? isdeleted { get; set; }
        public DateTime? deleted_at { get; set; }
    }
}
