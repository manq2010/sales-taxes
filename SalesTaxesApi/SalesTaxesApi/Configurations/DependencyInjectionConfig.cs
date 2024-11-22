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
            services.AddScoped<IReceiptsService, ReceiptsService>();
            services.AddScoped<ITaxService, TaxService>();

            services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent() + request.PathBase);
                return new UriService(uri);
            });

            return services;
        }
    }
}
