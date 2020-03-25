using GoodsLogistics.DI.Projects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GoodsLogistics.DI
{
    public static class DiConfigurator
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            AuthDiConfigurator.Configure(services, configuration);

            AutomapperDiConfigurator.Configure(services);

            ServicesDataDiConfigurator.Configure(services);

            HttpClientDiConfigurator.Configure(services);
        }
    }
}
