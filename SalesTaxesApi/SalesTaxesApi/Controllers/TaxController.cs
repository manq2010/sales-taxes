using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesTaxesApi.DbContexts;
using SalesTaxesApi.Interfaces;
using SalesTaxesApi.Models;

namespace SalesTaxesApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TaxController : Controller
    {
        #region Fields
        private readonly SalesTaxesDBContext _context;
        private ILogger<TaxController> _logger;
        private readonly ITaxService _taxService;
        #endregion

        #region Constructors
        public TaxController(
            SalesTaxesDBContext context,
            ITaxService taxService,
            ILogger<TaxController> logger
            )
        {
            _context = context;
            _taxService = taxService;
            _logger = logger;
        }

        #endregion

        #region Tax

        [HttpPost("PostInsertTaxType")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(TaxType))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UpdateResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostInsertTaxType(TaxType taxType)
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
                if (taxType.taxTypeId == 0)
                {
                    // Create a new taxType
                    var newTaxTypeResultResult = await _taxService.CreateTaxType(taxType);

                    if (newTaxTypeResultResult.Success)
                    {
                        return Ok(newTaxTypeResultResult);
                    }

                    return BadRequest(new CreateResult
                    {
                        Success = false,
                        ErrorMessage = "Failed to insert tax type. Invalid condition."
                    });
                } 
                else
                {
                    // Update existing taxType
                    if (!TaxTypeExists(taxType.taxTypeId))
                    {
                        return NotFound();
                    }

                    var updatedTaxTypeResultResult = await _taxService.UpdateTaxType(taxType);

                    if (updatedTaxTypeResultResult.Success)
                    {
                        return Ok(updatedTaxTypeResultResult);
                    }

                    return BadRequest(new CreateResult
                    {
                        Success = false,
                        ErrorMessage =  "Failed to update tax type. Invalid condition."
                    });


                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception from TaxController.PostInsertTaxType");
                return Problem("Unable to process the tax type.");
            }
        }

        [HttpDelete("DeleteTaxTypeById")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CreateResult))]
        public async Task<IActionResult> DeleteTaxTypeById(int id)
        {
            try
            {
                if (!TaxTypeExists(id))
                {
                    return NotFound($"Tax type with ID {id} was not found.");
                }

                var result = await _taxService.DeleteTaxTypeById(id);

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
                _logger.LogError(ex, "Unhandled exception from TaxController.DeleteTaxTypeById");
                return Problem("Unable to delete the tax type");
            }
        }

        [HttpGet("GetTaxTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaxType))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetTaxTypeById(int id)
        {
            try
            {
                var taxType = _taxService.GetTaxTypeById(id);
                if (taxType == null)
                {
                    return NotFound($"Tax type with ID {id} was not found.");
                }

                return Ok(new ResponseResult
                {
                    Status = "Success",
                    Message = "Successfully returned tax type",
                    DetailDescription = new
                    {
                        TaxType = taxType
                    }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception from TaxController.GetTaxTypeById");
                return Problem("Unable to Get the tax type");
            }
        }

        #endregion

        #region Helper Methods

        private bool TaxTypeExists(int id)
        {
            return _context.TaxTypes.Any(e => e.taxTypeId == id);
        }

        #endregion
 
    }
}
