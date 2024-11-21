using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SalesTaxesApi.DbContexts;
using SalesTaxesApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesTaxesApi.Services
{
    public class LookupService
    {
        private readonly SalesTaxesDBContext _context;
        private readonly IConfiguration _configuration;
        private ILogger<LookupService> _logger;

        public LookupService(
              SalesTaxesDBContext context,
              IConfiguration configuration,
              ILogger<LookupService> logger
          )
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        

    }
}
