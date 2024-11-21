using SalesTaxesApi.Models;

namespace SalesTaxesApi.Interfaces
{
    public interface IProductService
    {
        Task<CreateResult> CreateProduct(Product product);
        Task<CreateResult> CreateProductType(ProductType productType);
        Task<UpdateResult> UpdateProduct(Product product);
        Task<UpdateResult> UpdateProductType(ProductType productType);
        Task<DeleteResult> DeleteProductById(int id);
        Task<DeleteResult> DeleteProductTypeById(int id);
        Product GetProductById(int id);
        ProductType GetProductTypeById(int id);
        void Save();
    }
}
