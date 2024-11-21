using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxesApi.Dtos
{
    [NotMapped]
    public class ResponseDto
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
