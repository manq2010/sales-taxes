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
        private readonly IConfiguration _configuration;
        private ILogger<ReceiptService> _logger;

        public ReceiptService(
              SalesTaxesDBContext context,
              IConfiguration configuration,
              ILogger<ReceiptService> logger
          )
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        

    }
}
