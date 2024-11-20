using Microsoft.AspNetCore.Identity;

namespace SalesTaxesApi.Models
{
    public class MyUser : IdentityUser
    {
        public bool IsActive { get; set; }
        public bool IsAdminUser { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}