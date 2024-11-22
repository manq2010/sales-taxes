using SalesTaxesApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxesApi.Models
{
    [NotMapped]
    public class DeleteResult : UpdateResult
    {
        public string SuccessMessages { get; set; }
        public static new DeleteResult SuccessResult(string message)
        {
            return new DeleteResult
            {
                Success = true,
                SuccessMessages = message
            };
        }

        public static new DeleteResult FailureResult(string message)
        {
            return new DeleteResult
            {
                Success = false,
                ErrorMessage = message
            };
        }
    }
}
