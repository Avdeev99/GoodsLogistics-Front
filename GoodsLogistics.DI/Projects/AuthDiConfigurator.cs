using GoodsLogistics.Auth.Options;
using GoodsLogistics.Auth.Providers;
using GoodsLogistics.Auth.Providers.Interfaces;
using GoodsLogistics.Auth.Services;
using GoodsLogistics.Auth.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoodsLogistics.DI.Projects
{
    internal static class AuthDiConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CookieAuthOptions>(configuration.GetSection(nameof(CookieAuthOptions)));

            services.AddScoped<ICookiesService, CookiesService>();

            services.AddScoped<IApiServiceProvider, ApiServiceProvider>();
        }
    }
}
