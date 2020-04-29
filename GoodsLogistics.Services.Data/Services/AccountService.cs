using System.Threading.Tasks;
using GoodsLogistics.Auth.Providers.Interfaces;
using GoodsLogistics.Services.Data.Services.Interfaces;

namespace GoodsLogistics.Services.Data.Services
{
    public class AccountService : IAccountService
    {
        private readonly IResponseService _responseService;
        private readonly IApiServiceProvider _apiServiceProvider;


        public AccountService(
            IResponseService responseService, 
            IApiServiceProvider apiServiceProvider)
        {
            _responseService = responseService;
            _apiServiceProvider = apiServiceProvider;
        }

        public async Task DatabaseBackUp()
        {
            var url = $"https://localhost:44380/database/backUp";
            await _apiServiceProvider.GetAsync(
                url,
                true);
        }
    }
}
