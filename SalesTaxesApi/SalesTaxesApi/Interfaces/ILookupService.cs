using Microsoft.AspNetCore.Mvc;
using SalesTaxesApi.Dtos;
using SalesTaxesApi.Models;

namespace SalesTaxesApi.Interfaces
{
    public interface ILookupService
    {
        Task<ResponsePaged<List<PagedReceiptDto>>> GetPagedAllReceipts([FromQuery] PaginationFilter filter);
        IEnumerable<ProductType> GetAllProductTypes();
        IEnumerable<Product> GetAllImportedGoods();
        IEnumerable<Product> GetAllLocalGoods();
        IEnumerable<TaxType> GetAllTaxTypes();
    }
}
