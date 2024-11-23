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
    public class ReceiptsService : IReceiptsService
    {
        private readonly SalesTaxesDBContext _context;
        private ILogger<ReceiptsService> _logger;

        public ReceiptsService(
              SalesTaxesDBContext context,
              ILogger<ReceiptsService> logger
          )
        {
            _context = context;
            _logger = logger;
        }
        public Task<CreateResult> CreateReceipt(Receipt receipt)
        {
            receipt.created_at = DateTime.Now;
            receipt.updated_at = DateTime.Now;
            receipt.isDeleted = false;

            _context.Receipts.Add(receipt);
            Save();

            return Task.FromResult(CreateResult.SuccessResult(receipt.receiptId));
        }
        public Task<CreateResult> CreateReceiptItem(ReceiptItem receiptItem)
        {
            receiptItem.created_at = DateTime.Now;
            receiptItem.updated_at = DateTime.Now;
            receiptItem.isDeleted = false;

            _context.ReceiptItems.Add(receiptItem);
            Save();

            return Task.FromResult(CreateResult.SuccessResult(receiptItem.receiptItemId));
        }

        public Task<UpdateResult> UpdateReceipt(Receipt receipt)
        {
            receipt.updated_at = DateTime.Now;
            receipt.isDeleted = false;

            _context.Receipts.Update(receipt);
            Save();

            return Task.FromResult(UpdateResult.SuccessResultUpdate(receipt.receiptId));
        }

        public Receipt? GetReceiptById(int id)
        {
            var receipt = _context.Receipts
                    .Where(d => d.receiptId == id)
                    .Include(ri =>ri.ReceiptItems)
                    .FirstOrDefault();

            if (receipt == null)
            {
                return null;
            }

            return receipt;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
