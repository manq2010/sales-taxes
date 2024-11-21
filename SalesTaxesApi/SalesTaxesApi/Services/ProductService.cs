using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SalesTaxesApi.DbContexts;
using SalesTaxesApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesTaxesApi.Services
{
    public class ProductService
    {
        private readonly SalesTaxesDBContext _context;
        private readonly IConfiguration _configuration;
        private ILogger<ProductService> _logger;

        public ProductService(
              SalesTaxesDBContext context,
              IConfiguration configuration,
              ILogger<ProductService> logger
          )
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        

    }
}
