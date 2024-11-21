using SalesTaxesApi.Models;

namespace SalesTaxesApi.Interfaces
{
    public interface ILookupService
    {
        IEnumerable<ProductType> GetAllProductTypes();
        IEnumerable<TaxType> GetAllTaxTypes();
    }
}
