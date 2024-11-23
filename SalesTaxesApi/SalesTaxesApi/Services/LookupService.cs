using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SalesTaxesApi.DbContexts;
using SalesTaxesApi.Interfaces;
using SalesTaxesApi.Models;
using SalesTaxesApi.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SalesTaxesApi.Dtos;

namespace SalesTaxesApi.Services
{
    public class LookupService: ILookupService
    {
        private readonly SalesTaxesDBContext _context;
        private ILogger<LookupService> _logger;
        private readonly IUriService _uriService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LookupService(
              SalesTaxesDBContext context,
              ILogger<LookupService> logger,
              IUriService uriService, 
              IHttpContextAccessor httpContextAccessor
          )
        {
            _context = context;
            _logger = logger;
            _uriService = uriService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<ResponsePaged<List<PagedReceiptDto>>> GetPagedAllReceipts([FromQuery] PaginationFilter filter)
        {
            var route = _httpContextAccessor.HttpContext?.Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var pagedData = _context.Receipts
                .Where(d => d.isDeleted == false)
                .OrderByDescending(d => d.receiptId)
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .Select(receipt => new PagedReceiptDto
                {
                    ReceiptId = receipt.receiptId,
                    ClientName = receipt.clientName,
                    ClientEmail = receipt.clientEmail,
                    TotalTaxes = receipt.totalTaxes,
                    TotalCost = receipt.totalCost,
                    CreatedAt = receipt.created_at
                })
                .ToList();

            var totalRecords = _context.Receipts.Where(d => d.isDeleted == false).Count();

            var pagedReponse = PaginationConfig.CreatePagedReponse<PagedReceiptDto>(pagedData, validFilter, totalRecords, _uriService, route);
            return pagedReponse;

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
        public IEnumerable<Product> GetAllImportedGoods()
        {
            return _context.Products
            .Where(d => d.isDeleted == false && d.isImport == true)
            .ToList();
        }
        public IEnumerable<Product> GetAllLocalGoods()
        {
            return _context.Products
            .Where(d => d.isDeleted == false && d.isImport == false)
            .ToList();
        }

        public IEnumerable<Product> GetAllGoods()
        {
            return _context.Products
            .Where(d => d.isDeleted == false)
            .ToList();
        }


    }
}
