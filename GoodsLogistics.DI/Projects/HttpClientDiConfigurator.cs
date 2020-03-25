using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace GoodsLogistics.DI.Projects
{
    internal static class HttpClientDiConfigurator
    {
        public static void Configure(IServiceCollection services)
        {
            var httpClient = new HttpClient();
            services.AddSingleton(httpClient);
        }
    }
}
