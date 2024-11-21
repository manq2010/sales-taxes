using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SalesTaxesApi.DbContexts;
using SalesTaxesApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesTaxesApi.Services
{
    public class ReceiptService
    {
        private readonly SalesTaxesDBContext _context;
        private ILogger<ReceiptService> _logger;

        public ReceiptService(
              SalesTaxesDBContext context,
              ILogger<ReceiptService> logger
          )
        {
            _context = context;
            _logger = logger;
        }

        

    }
}
