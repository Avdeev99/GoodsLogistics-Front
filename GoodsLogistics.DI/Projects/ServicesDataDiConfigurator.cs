using GoodsLogistics.Services.Data.Services;
using GoodsLogistics.Services.Data.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GoodsLogistics.DI.Projects
{
    internal static class ServicesDataDiConfigurator
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IUserCompanyService, UserCompanyService>();

            services.AddScoped<IResponseService, ResponseService>();

            services.AddScoped<IOfficeService, OfficeService>();

            services.AddScoped<ILocationService, LocationService>();

            services.AddScoped<IObjectiveService, ObjectiveService>();
        }
    }
}
