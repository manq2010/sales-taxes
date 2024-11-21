using SalesTaxesApi.DbContexts;
using SalesTaxesApi.Interfaces;
using SalesTaxesApi.Models;

namespace SalesTaxesApi.Services
{
    public class TaxService : ITaxService
    {
        private readonly SalesTaxesDBContext _context;
        private readonly IConfiguration _configuration;
        private ILogger<TaxService> _logger;

        public TaxService(
              SalesTaxesDBContext context,
              IConfiguration configuration,
              ILogger<TaxService> logger
          )
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
        }

        public Task<CreateResult> CreateTaxType(TaxType taxType)
        {
            taxType.created_at = DateTime.Now;
            taxType.updated_at = DateTime.Now;
            taxType.isDeleted = false;

            _context.TaxTypes.Add(taxType);
            Save();

            return Task.FromResult(CreateResult.SuccessResult(taxType.taxTypeId));
        }

        public Task<UpdateResult> UpdateTaxType(TaxType taxType)
        {
            taxType.updated_at = DateTime.Now;
            taxType.isDeleted = false;

            _context.TaxTypes.Update(taxType);
            Save();

            return Task.FromResult(UpdateResult.SuccessResultUpdate(taxType.taxTypeId));
        }

        public TaxType GetTaxTypeById(int id)
        {
            return _context.TaxTypes
                    .Where(d => d.taxTypeId == id)
                    .First();
        }

        public Task<DeleteResult> DeleteTaxTypeById(int id)
        {
            var subscription = _context.TaxTypes.First(a => a.taxTypeId == id);

            if (subscription != null)
            {
                subscription.isDeleted = true;
                subscription.deleted_at = DateTime.Now;

                Save();
                return Task.FromResult(DeleteResult.SuccessResult("Successfully deleted tax type"));
            }
            else
            {
                return Task.FromResult(DeleteResult.FailureResult("Failed to delete tax type"));
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
