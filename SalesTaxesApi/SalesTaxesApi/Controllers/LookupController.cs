using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesTaxesApi.DbContexts;
using SalesTaxesApi.Dtos;
using SalesTaxesApi.Interfaces;
using SalesTaxesApi.Models;

namespace SalesTaxesApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LookupController : Controller
    {
        #region Fields
        private readonly SalesTaxesDBContext _context;
        private ILogger<LookupController> _logger;
        private readonly ILookupService _lookupService;
        #endregion

        #region Constructors
        public LookupController(
            SalesTaxesDBContext context,
            ILookupService lookupService,
            ILogger<LookupController> logger
            )
        {
            _context = context;
            _lookupService = lookupService;
            _logger = logger;
        }
        #endregion

        #region Lookup
        [HttpGet("GetPagedAllReceipts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPagedAllReceipts([FromQuery] PaginationFilter filter)
        {
            if (filter == null)
            {
                return new BadRequestResult();
            }

            try
            {
                var pagedReceipts = await _lookupService.GetPagedAllReceipts(filter);
                return new OkObjectResult(pagedReceipts);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to get paged adverts");
                return Problem("Unable to get paged adverts");
            }
        }

        [HttpGet("GetAllProductTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllProductTypes()
        {
            try
            {
                var productTypes = _lookupService.GetAllProductTypes();

                var toReturn = productTypes.Select(pt => new ProductTypeDto
                {
                    ProductTypeId = pt.productTypeId,
                    ProductTypeName = pt.productTypeName,
                    IsExempt = pt.isExempt

                }).ToList();

                return new OkObjectResult(toReturn);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception from LookupController.GetAllProductTypes");
                return Problem("Unable to process GetAllProductTypes.");
            }
        }


        [HttpGet("GetAllTaxTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllTaxTypes()
        {
            try
            {
                var taxTypes = _lookupService.GetAllTaxTypes();

                var toReturn = taxTypes.Select(tt => new TaxTypeDto
                {
                    TaxTypeId = tt.taxTypeId,
                    TaxName = tt.taxName,
                    Rate = tt.rate

                }).ToList();

                return new OkObjectResult(toReturn);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception from LookupController.GetAllTaxTypes");
                return Problem("Unable to process GetAllTaxTypes.");
            }
        }

        [HttpGet("GetAllImportedGoods")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllImportedGoods()
        {
            try
            {
                var importedGoods = _lookupService.GetAllImportedGoods();

                var toReturn = importedGoods.Select(p => new ProductDto
                {
                    ProductId = p.productId,
                    ProductName = p.productName,
                    UnitPrice = p.unitPrice,
                    IsImport = p.isImport

                }).ToList();

                return new OkObjectResult(toReturn);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception from LookupController.GetAllImportedGoods");
                return Problem("Unable to process GetAllImportedGoods.");
            }
        }

        [HttpGet("GetAllLocalGoods")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllLocalGoods()
        {
            try
            {
                var localGoods = _lookupService.GetAllLocalGoods();

                var toReturn = localGoods.Select(p => new ProductDto
                {
                    ProductId = p.productId,
                    ProductName = p.productName,
                    UnitPrice = p.unitPrice,
                    IsImport = p.isImport

                }).ToList();

                return new OkObjectResult(toReturn);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception from LookupController.GetAllLocalGoods");
                return Problem("Unable to process GetAllLocalGoods.");
            }
        }

        #endregion

    }
}
