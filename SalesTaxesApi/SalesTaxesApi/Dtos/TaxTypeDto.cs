using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxesApi.Dtos
{
    [NotMapped]
    public class TaxTypeDto
    {
        public int TaxTypeId { get; set; }
        public string TaxName { get; set; }
        public decimal Rate { get; set; }
    }
}
