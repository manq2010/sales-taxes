using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SalesTaxesApi.DbContexts;
using SalesTaxesApi.Interfaces;
using SalesTaxesApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesTaxesApi.Services
{
    public class ProductService : IProductService
    {
        private readonly SalesTaxesDBContext _context;
        private ILogger<ProductService> _logger;

        public ProductService(
              SalesTaxesDBContext context,
              ILogger<ProductService> logger
          )
        {
            _context = context;
            _logger = logger;
        }

        public Task<CreateResult> CreateProduct(Product product)
        {
            product.created_at = DateTime.Now;
            product.updated_at = DateTime.Now;
            product.isDeleted = false;

            _context.Products.Add(product);
            Save();

            return Task.FromResult(CreateResult.SuccessResult(product.productId));
        }
        public Task<CreateResult> CreateProductType(ProductType productType)
        {
            productType.created_at = DateTime.Now;
            productType.updated_at = DateTime.Now;
            productType.isDeleted = false;

            _context.ProductTypes.Add(productType);
            Save();

            return Task.FromResult(CreateResult.SuccessResult(productType.productTypeId));
        }

        public Task<UpdateResult> UpdateProduct(Product product)
        {
            product.updated_at = DateTime.Now;
            product.isDeleted = false;

            _context.Products.Update(product);
            Save();

            return Task.FromResult(UpdateResult.SuccessResultUpdate(product.productId));
        }

        public Task<UpdateResult> UpdateProductType(ProductType productType)
        {
            productType.updated_at = DateTime.Now;
            productType.isDeleted = false;

            _context.ProductTypes.Update(productType);
            Save();

            return Task.FromResult(UpdateResult.SuccessResultUpdate(productType.productTypeId));
        }

        public Product? GetProductById(int id)
        {
            var product = _context.Products
                    .Where(d => d.productId == id)
                    .FirstOrDefault();

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public ProductType? GetProductTypeById(int id)
        {
            var productType = _context.ProductTypes
                    .Where(d => d.productTypeId == id)
                    .FirstOrDefault();

            if (productType == null)
            {
                return null;
            }

            return productType;
        }

        public Task<DeleteResult> DeleteProductById(int id)
        {
            var product = _context.Products.First(a => a.productId == id);

            if (product != null)
            {
                product.isDeleted = true;
                product.deleted_at = DateTime.Now;

                Save();
                return Task.FromResult(DeleteResult.SuccessResult("Successfully deleted product"));
            }
            else
            {
                return Task.FromResult(DeleteResult.FailureResult("Failed to delete product"));
            }
        }

        public Task<DeleteResult> DeleteProductTypeById(int id)
        {
            var productType = _context.ProductTypes.First(a => a.productTypeId == id);

            if (productType != null)
            {
                productType.isDeleted = true;
                productType.deleted_at = DateTime.Now;

                Save();
                return Task.FromResult(DeleteResult.SuccessResult("Successfully deleted product type"));
            }
            else
            {
                return Task.FromResult(DeleteResult.FailureResult("Failed to delete product type"));
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
