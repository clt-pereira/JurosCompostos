using APICalculoJuros.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace APICalculoJuros.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpClient<ICalculaJurosService, CalculaJurosService>();
        }
    }
}
