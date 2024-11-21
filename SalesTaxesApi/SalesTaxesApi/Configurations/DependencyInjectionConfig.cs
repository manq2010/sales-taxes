using SalesTaxesApi.Interfaces;
using SalesTaxesApi.Services;

namespace SalesTaxesApi.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddHttpClient();
            //services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<ILookupService, LookupService>();
            services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<ITaxService, TaxService>();

            return services;
        }
    }
}
