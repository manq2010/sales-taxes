using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxesApi.Dtos
{
    [NotMapped]
    public class ProductTypeDto
    {
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public bool? IsExempt { get; set; }
    }
}
