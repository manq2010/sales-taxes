using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalesTaxesApi.Models
{
    /// <summary>
    /// Represents a Tax Type in the system.
    /// </summary>
    [Table("TaxType")]
    public class TaxType
    {
        /// <summary>
        /// Gets or sets the ID of the Tax type.
        /// </summary>
        [Key]
        public int taxTypeId { get; set; }
        [Required] 
        public string taxName { get; set; } = string.Empty;
        public decimal rate { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime deleted_at { get; set; }
    }
}
