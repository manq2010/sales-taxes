using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SalesTaxesApi.DbContexts;
using SalesTaxesApi.Interfaces;
using SalesTaxesApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesTaxesApi.Services
{
    public class LookupService: ILookupService
    {
        private readonly SalesTaxesDBContext _context;
        private ILogger<LookupService> _logger;

        public LookupService(
              SalesTaxesDBContext context,
              ILogger<LookupService> logger
          )
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<ProductType> GetAllProductTypes()
        {
            return _context.ProductTypes
            .Where(d => d.isDeleted == false)
            .ToList();
        }

        public IEnumerable<TaxType> GetAllTaxTypes()
        {
            return _context.TaxTypes
            .Where(d => d.isDeleted == false)
            .ToList();
        }


    }
}
