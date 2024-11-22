using SalesTaxesApi.Models;

namespace SalesTaxesApi.Interfaces
{
    public interface IReceiptsService
    {
        Task<CreateResult> CreateReceipt(Receipt receipt);
        Task<CreateResult> CreateReceiptItem(ReceiptItem receiptItem);
        Task<UpdateResult> UpdateReceipt(Receipt receipt);
        //Task<UpdateResult> UpdateReceiptItem(ReceiptItem receiptItem);
        //Task<DeleteResult> DeleteReceiptItemById(int id);
        //Product GetReceiptItemById(int id);
        void Save();
    }
}
