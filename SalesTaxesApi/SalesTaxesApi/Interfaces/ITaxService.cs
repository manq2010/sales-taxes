using SalesTaxesApi.Models;

namespace SalesTaxesApi.Interfaces
{
    public interface ITaxService
    {
        Task<CreateResult> CreateTaxType(TaxType taxType);
        Task<UpdateResult> UpdateTaxType(TaxType taxType);
        Task<DeleteResult> DeleteTaxTypeById(int id);
        TaxType GetTaxTypeById(int id);
        void Save();
    }
}
