using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxesApi.Models
{
    [NotMapped]
    public class ResponseResult
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public IdentityResult Detail { get; set; }
        public object DetailDescription { get; set; }
    }
}
