using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoodsLogistics.Auth.Providers.Interfaces;
using GoodsLogistics.Models.DTO;
using GoodsLogistics.Models.DTO.Objective;
using GoodsLogistics.Services.Data.Services.Interfaces;

namespace GoodsLogistics.Services.Data.Services
{
    public class ObjectiveService : IObjectiveService
    {
        private readonly IApiServiceProvider _apiServiceProvider;
        private readonly IResponseService _responseService;

        public ObjectiveService(
            IApiServiceProvider apiServiceProvider,
            IResponseService responseService)
        {
            _apiServiceProvider = apiServiceProvider;
            _responseService = responseService;
        }

        public async Task<ServiceResponseModel<List<ObjectiveModel>>> GetObjectives()
        {
            var url = $"https://localhost:44380/objectives";
            var httpResponse = await _apiServiceProvider.GetAsync(
                url,
                true);

            var result = await _responseService.CreateResponse<List<ObjectiveModel>>(httpResponse);
            return result;
        }

        public async Task<ServiceResponseModel<ObjectiveModel>> GetObjectiveById(string id)
        {
            var url = $"https://localhost:44380/objectives/{id}";
            var httpResponse = await _apiServiceProvider.GetAsync(
                url,
                true);

            var result = await _responseService.CreateResponse<ObjectiveModel>(httpResponse);
            return result;
        }

        public async Task<ServiceResponseModel<ObjectiveModel>> CreateObjective(ObjectiveModel createRequestModel)
        {
            var url = "https://localhost:44380/objectives";
            var httpResponse = await _apiServiceProvider.PostAsync(
                url,
                createRequestModel,
                true);

            var result = await _responseService.CreateResponse<ObjectiveModel>(httpResponse);
            return result;
        }

        public async Task<ServiceResponseModel<ObjectiveModel>> UpdateObjective(
            string id,
            ObjectiveUpdateRequestModel updateRequestModel)
        {
            var url = $"https://localhost:44380/objectives/{id}";
            var httpResponse = await _apiServiceProvider.PatchAsync(
                url,
                updateRequestModel,
                true);

            var result = await _responseService.CreateResponse<ObjectiveModel>(httpResponse);
            return result;
        }

        public async Task DeleteObjective(string id)
        {
            var url = $"https://localhost:44380/objectives/{id}";
            await _apiServiceProvider.DeleteAsync(
                url,
                true);
        }
    }
}
