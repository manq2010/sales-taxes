using SalesTaxesApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxesApi.Models
{
    [NotMapped]
    public class CreateResult : UpdateResult
    {
        public int NewId { get; set; }

        public static CreateResult SuccessResult(int id)
        {
            return new CreateResult
            {
                Success = true,
                NewId = id,
            };
        }

        public static CreateResult FailureResult(string errorMessage)
        {
            return new CreateResult
            {
                Success = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
