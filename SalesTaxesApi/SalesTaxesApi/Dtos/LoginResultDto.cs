using System.ComponentModel.DataAnnotations.Schema;

namespace SalesTaxesApi.Dtos
{
    [NotMapped]
    public class LoginResultDto
    {
        public bool Success { get; set; }
        public string? ErrorMessages { get; set; }

        public static LoginResultDto FailureResult(string errorMessage)
        {
            return new LoginResultDto
            {
                Success = false,
                ErrorMessages = errorMessage
            };
        }
    }
}
