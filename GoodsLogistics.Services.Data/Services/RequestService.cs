using System.Collections.Generic;
using System.Threading.Tasks;
using GoodsLogistics.Auth.Providers.Interfaces;
using GoodsLogistics.Models.DTO;
using GoodsLogistics.Models.DTO.Office;
using GoodsLogistics.Models.DTO.Request;
using GoodsLogistics.Services.Data.Services.Interfaces;

namespace GoodsLogistics.Services.Data.Services
{
    public class RequestService : IRequestService
    {
        private readonly IApiServiceProvider _apiServiceProvider;
        private readonly IResponseService _responseService;

        public RequestService(
            IApiServiceProvider apiServiceProvider, 
            IResponseService responseService)
        {
            _apiServiceProvider = apiServiceProvider;
            _responseService = responseService;
        }

        public async Task<ServiceResponseModel<List<RequestModel>>> GetRequests()
        {
            var url = $"https://localhost:44380/requests";
            var httpResponse = await _apiServiceProvider.GetAsync(
                url,
                true);

            var result = await _responseService.CreateResponse<List<RequestModel>>(httpResponse);
            return result;
        }

        public async Task<ServiceResponseModel<List<RequestModel>>> GetRequestsByCompanyId(string id)
        {
            var url = $"https://localhost:44380/company/{id}/requests";
            var httpResponse = await _apiServiceProvider.GetAsync(
                url,
                true);

            var result = await _responseService.CreateResponse<List<RequestModel>>(httpResponse);
            return result;
        }

        public async Task<ServiceResponseModel<RequestModel>> GetRequestById(string id)
        {
            var url = $"https://localhost:44380/offices/{id}";
            var httpResponse = await _apiServiceProvider.GetAsync(
                url,
                true);

            var result = await _responseService.CreateResponse<RequestModel>(httpResponse);
            return result;
        }

        public async Task<ServiceResponseModel<RequestModel>> CreateRequest(RequestModel createRequestModel)
        {
            var url = "https://localhost:44380/requests";
            var httpResponse = await _apiServiceProvider.PostAsync(
                url,
                createRequestModel,
                true);

            var result = await _responseService.CreateResponse<RequestModel>(httpResponse);
            return result;
        }

        public async Task<ServiceResponseModel<RequestModel>> UpdateRequest(string id, RequestUpdateModel updateRequestModel)
        {
            var url = $"https://localhost:44380/requests/{id}";
            var httpResponse = await _apiServiceProvider.PatchAsync(
                url,
                updateRequestModel,
                true);

            var result = await _responseService.CreateResponse<RequestModel>(httpResponse);
            return result;
        }

        public async Task DeleteRequest(string id)
        {
            var url = $"https://localhost:44380/requests/{id}";
            await _apiServiceProvider.DeleteAsync(
                url,
                true);
        }
    }
}
