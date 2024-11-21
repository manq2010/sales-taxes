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
        [Range(1, 1000000)]
        public decimal quantity { get; set; }
        public int productTypeId { get; set; }
        [Range(0.01, 9999999.99)]
        public decimal unitPrice { get; set; }
        public bool isImported { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime deleted_at { get; set; }
        public virtual List<ProductType> ProductType { get; set; } = new List<ProductType>();
    }
}
