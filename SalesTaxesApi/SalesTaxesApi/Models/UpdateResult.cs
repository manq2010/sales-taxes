using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxesApi.Models
{
    [NotMapped]
    public class UpdateResult
    {
        public bool Success { get; set; }
        public int OldId { get; set; }
        public string ErrorMessage { get; set; }

        public static UpdateResult SuccessResult()
        {
            return new UpdateResult { Success = true };
        }

        public static UpdateResult SuccessResultUpdate(int oldId)
        {
            return new UpdateResult
            {
                Success = true,
                OldId = oldId
            };
        }

        public static UpdateResult FailureResult(string errorMessage)
        {
            return new UpdateResult
            {
                Success = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
