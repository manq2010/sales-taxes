using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesTaxesApi.DbContexts;
using SalesTaxesApi.Interfaces;
using SalesTaxesApi.Models;
using SalesTaxesApi.Services;
using System.Net.Mime;

namespace SalesTaxesApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : Controller
    {
        #region Fields
        private readonly SalesTaxesDBContext _context;
        private ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        #endregion

        #region Constructors
        public ProductController(
            SalesTaxesDBContext context,
            IProductService productService,
            ILogger<ProductController> logger
            )
        {
            _context = context;
            _productService = productService;
            _logger = logger;
        }
        #endregion

        #region Product

        [HttpPost("PostInsertProduct")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UpdateResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostInsertProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = string.Join("; ", ModelState
                                 .Where(kvp => kvp.Value.Errors.Any())
                                 .Select(kvp => $"{kvp.Key}: {string.Join(", ", kvp.Value.Errors.Select(e => e.ErrorMessage))}"));


                return BadRequest(new CreateResult
                {
                    Success = false,
                    ErrorMessage = errorMessages
                });
            }

            try
            {
                if (product.productId == 0)
                {
                    // Create a new product
                    var newProductResult = await _productService.CreateProduct(product);

                    if (newProductResult.Success)
                    {
                        return Ok(newProductResult);
                    }

                    return BadRequest(new CreateResult
                    {
                        Success = false,
                        ErrorMessage = "Failed to insert product. Invalid condition."
                    });
                }
                else
                {
                    // Update existing product
                    if (!ProductExists(product.productTypeId))
                    {
                        return NotFound();
                    }

                    var updatedProductResultResult = await _productService.UpdateProduct(product);

                    if (updatedProductResultResult.Success)
                    {
                        return Ok(updatedProductResultResult);
                    }

                    return BadRequest(new CreateResult
                    {
                        Success = false,
                        ErrorMessage = "Failed to update product. Invalid condition."
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception from ProductController.PostInsertProduct");
                return Problem("Unable to process the product.");
            }
        }

        [HttpPost("PostInsertProductType")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(ProductType))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UpdateResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostInsertProductType(ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = string.Join("; ", ModelState
                                 .Where(kvp => kvp.Value.Errors.Any())
                                 .Select(kvp => $"{kvp.Key}: {string.Join(", ", kvp.Value.Errors.Select(e => e.ErrorMessage))}"));


                return BadRequest(new CreateResult
                {
                    Success = false,
                    ErrorMessage = errorMessages
                });
            }

            try
            {
                if (productType.productTypeId == 0)
                {
                    // Create a new product type
                    var newProductTypeResult = await _productService.CreateProductType(productType);

                    if (newProductTypeResult.Success)
                    {
                        return Ok(newProductTypeResult);
                    }

                    return BadRequest(new CreateResult
                    {
                        Success = false,
                        ErrorMessage = "Failed to insert product type. Invalid condition."
                    });
                }
                else
                {
                    // Update existing product type
                    if (!ProductExists(productType.productTypeId))
                    {
                        return NotFound();
                    }

                    var updatedProductTypeResultResult = await _productService.UpdateProductType(productType);

                    if (updatedProductTypeResultResult.Success)
                    {
                        return Ok(updatedProductTypeResultResult);
                    }

                    return BadRequest(new CreateResult
                    {
                        Success = false,
                        ErrorMessage = "Failed to update product type. Invalid condition."
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception from ProductController.PostInsertProductType");
                return Problem("Unable to process the product type.");
            }
        }

        [HttpDelete("DeleteProductById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreateResult))]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            try
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }

                var result = await _productService.DeleteProductById(id);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return new BadRequestResult();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception from ProductController.DeleteProductById");
                return Problem("Unable to delete the product");
            }
        }

        [HttpDelete("DeleteProductTypeById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreateResult))]
        public async Task<IActionResult> DeleteProductTypeById(int id)
        {
            try
            {
                if (!ProductTypeExists(id))
                {
                    return NotFound();
                }

                var result = await _productService.DeleteProductTypeById(id);

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return new BadRequestResult();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception from ProductController.DeleteProductTypeById");
                return Problem("Unable to delete the product type");
            }
        }

        [HttpGet("GetProductById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound($"Product with ID {id} was not found.");
                }

                return Ok(new ResponseResult
                {
                    Status = "Success",
                    Message = "Successfully returned product",
                    DetailDescription = new
                    {
                        Product = product
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception from ProductController.GetProductById");
                return Problem("Unable to Get the product");
            }
        }

        [HttpGet("GetProductTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductType))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProductTypeById(int id)
        {
            try
            {
                var productType = _productService.GetProductTypeById(id);
                if (productType == null)
                {
                    return NotFound($"Product type with ID {id} was not found.");
                }

                return Ok(new ResponseResult
                {
                    Status = "Success",
                    Message = "Successfully returned product type",
                    DetailDescription = new
                    {
                        ProductType = productType
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception from ProductController.GetProductTypeById");
                return Problem("Unable to Get the product type");
            }
        }

        #endregion

        #region Helper Methods
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.productTypeId == id);
        }

        private bool ProductTypeExists(int id)
        {
            return _context.ProductTypes.Any(e => e.productTypeId == id);
        }
        #endregion

    }
}
