using SalesTaxesApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxesApi.Dtos
{
    [NotMapped]
    public class PagedReceiptDto
    {
        public int ReceiptId { get; set; }
        public string ReceiptName { get; set; }
        public decimal TotalTaxes { get; set; }
        public decimal TotalCost { get; set; }
    }
}
