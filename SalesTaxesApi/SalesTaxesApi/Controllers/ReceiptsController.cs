using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesTaxesApi.DbContexts;
using SalesTaxesApi.Interfaces;
using SalesTaxesApi.Models;
using SalesTaxesApi.Services;

namespace SalesTaxesApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReceiptsController : Controller
    {
        #region Fields
        private readonly SalesTaxesDBContext _context;
        private ILogger<ReceiptsController> _logger;
        private readonly IReceiptsService _receiptsService;
        #endregion

        #region Constructors
        public ReceiptsController(
            SalesTaxesDBContext context,
            IReceiptsService receiptsService,
            ILogger<ReceiptsController> logger)
        {
            _context = context;
            _logger = logger;
            _receiptsService = receiptsService;
        }
        #endregion

        #region Receipts
        [HttpPost("PostInsertReceipt")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Receipt))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(UpdateResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostInsertReceipt(Receipt receipt)
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
                if (receipt.receiptId == 0)
                {
                    // Create a new receipt
                    var newReceiptResult = await _receiptsService.CreateReceipt(receipt);

                    if (newReceiptResult.Success)
                    {
                        return Ok(newReceiptResult);
                    }

                    return BadRequest(new CreateResult
                    {
                        Success = false,
                        ErrorMessage = "Failed to insert receipt. Invalid condition."
                    });
                }
                else
                {
                    // Update existing product
                    if (!ReceiptExists(receipt.receiptId))
                    {
                        return NotFound();
                    }

                    var updatedReceiptResultResult = await _receiptsService.UpdateReceipt(receipt);

                    if (updatedReceiptResultResult.Success)
                    {
                        return Ok(updatedReceiptResultResult);
                    }

                    return BadRequest(new CreateResult
                    {
                        Success = false,
                        ErrorMessage = "Failed to update receipt. Invalid condition."
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception from ProductController.PostInsertReceipt");
                return Problem("Unable to process the receipt.");
            }
        }
        #endregion


        #region Helper Methods
        private bool ReceiptExists(int id)
        {
            return _context.Receipts.Any(e => e.receiptId == id);
        }
        #endregion
    }
}
