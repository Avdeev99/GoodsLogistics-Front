using GoodsLogistics.Auth.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoodsLogistics.DI.Projects
{
    internal static class AuthDiConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CookieAuthOptions>(configuration.GetSection(nameof(CookieAuthOptions)));
        }
    }
}
