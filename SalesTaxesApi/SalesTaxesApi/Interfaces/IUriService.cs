using SalesTaxesApi.Models;

namespace SalesTaxesApi.Interfaces
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
