using APITaxaJuros.Services;
using Microsoft.Extensions.DependencyInjection;

namespace APITaxaJuros.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ITaxaJurosService, TaxaJurosService>();
        }
    }
}
