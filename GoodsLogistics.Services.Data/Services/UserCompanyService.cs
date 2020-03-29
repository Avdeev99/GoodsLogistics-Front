using System.Net.Http;
using System.Threading.Tasks;
using GoodsLogistics.Auth.Providers.Interfaces;
using GoodsLogistics.Models.DTO;
using GoodsLogistics.Models.DTO.UserCompany;
using GoodsLogistics.Services.Data.Services.Interfaces;

namespace GoodsLogistics.Services.Data.Services
{
    public class UserCompanyService : IUserCompanyService
    {
        private readonly IApiServiceProvider _apiServiceProvider;
        private readonly IResponseService _responseService;

        public UserCompanyService(
            IApiServiceProvider apiServiceProvider, 
            IResponseService responseService)
        {
            _apiServiceProvider = apiServiceProvider;
            _responseService = responseService;
        }

        public async Task<ServiceResponseModel<UserCompanyModel>> GetUserCompany(string email)
        {
            var url = $"https://localhost:44380/users/{email}";
            var httpResponse = await _apiServiceProvider.GetAsync(
                url, 
                true);

            var result = await _responseService.CreateResponse<UserCompanyModel>(httpResponse);
            return result;
        }

        public async Task<ServiceResponseModel<UserCompanyModel>> UpdateUserCompany(string email, UserCompanyUpdateRequestModel updateRequestModel)
        {
            var url = $"https://localhost:44380/users/{email}";
            var httpResponse = await _apiServiceProvider.PatchAsync(
                url,
                updateRequestModel,
                true);

            var result = await _responseService.CreateResponse<UserCompanyModel>(httpResponse);
            return result;
        }
    }
}
