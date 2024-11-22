using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalesTaxesApi.Models
{
    /// <summary>
    /// Represents a Product Type in the system.
    /// </summary>
    [Table("ProductType")]
    public class ProductType
    {
        /// <summary>
        /// Gets or sets the ID of the product type.
        /// </summary>
        [Key]
        public int productTypeId { get; set; }
        [Required]
        public string productTypeName { get; set; }
        public bool? isExempt { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime deleted_at { get; set; }
    }
}
