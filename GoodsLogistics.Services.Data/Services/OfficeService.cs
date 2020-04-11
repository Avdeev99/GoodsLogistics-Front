using System.Collections.Generic;
using System.Threading.Tasks;
using GoodsLogistics.Auth.Providers.Interfaces;
using GoodsLogistics.Models.DTO;
using GoodsLogistics.Models.DTO.Office;
using GoodsLogistics.Services.Data.Services.Interfaces;

namespace GoodsLogistics.Services.Data.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IApiServiceProvider _apiServiceProvider;
        private readonly IResponseService _responseService;

        public OfficeService(
            IApiServiceProvider apiServiceProvider, 
            IResponseService responseService)
        {
            _apiServiceProvider = apiServiceProvider;
            _responseService = responseService;
        }

        public async Task<ServiceResponseModel<List<OfficeModel>>> GetOffices()
        {
            var url = $"https://localhost:44380/offices";
            var httpResponse = await _apiServiceProvider.GetAsync(
                url,
                true);

            var result = await _responseService.CreateResponse<List<OfficeModel>>(httpResponse);
            return result;
        }

        public async Task<ServiceResponseModel<List<OfficeModel>>> GetOfficesByCompanyId(string id)
        {
            var url = $"https://localhost:44380/company/{id}/offices";
            var httpResponse = await _apiServiceProvider.GetAsync(
                url,
                true);

            var result = await _responseService.CreateResponse<List<OfficeModel>>(httpResponse);
            return result;
        }

        public async Task<ServiceResponseModel<OfficeModel>> GetOfficeByKey(string key)
        {
            var url = $"https://localhost:44380/offices/{key}";
            var httpResponse = await _apiServiceProvider.GetAsync(
                url,
                true);

            var result = await _responseService.CreateResponse<OfficeModel>(httpResponse);
            return result;
        }

        public async Task<ServiceResponseModel<OfficeModel>> CreateOffice(OfficeModel createRequestModel)
        {
            var url = "https://localhost:44380/offices";
            var httpResponse = await _apiServiceProvider.PostAsync(
                url,
                createRequestModel,
                true);

            var result = await _responseService.CreateResponse<OfficeModel>(httpResponse);
            return result;
        }

        public async Task<ServiceResponseModel<OfficeModel>> UpdateOffice(
            string key, 
            OfficeUpdateRequestModel updateRequestModel)
        {
            var url = $"https://localhost:44380/offices/{key}";
            var httpResponse = await _apiServiceProvider.PatchAsync(
                url,
                updateRequestModel,
                true);

            var result = await _responseService.CreateResponse<OfficeModel>(httpResponse);
            return result;
        }

        public async Task DeleteOffice(string key)
        {
            var url = $"https://localhost:44380/offices/{key}";
            await _apiServiceProvider.DeleteAsync(
                url,
                true);
        }
    }
}
