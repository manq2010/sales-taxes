using Microsoft.AspNetCore.Mvc;
using SalesTaxesApi.Models;

namespace SalesTaxesApi.Interfaces
{
    public interface ILookupService
    {
        Task<ResponseModel<List<Receipt>>> GetPagedAllReceipts([FromQuery] PaginationFilter filter);
        IEnumerable<ProductType> GetAllProductTypes();
        IEnumerable<Product> GetAllImportedGoods();
        IEnumerable<Product> GetAllLocalGoods();
        IEnumerable<TaxType> GetAllTaxTypes();
    }
}
