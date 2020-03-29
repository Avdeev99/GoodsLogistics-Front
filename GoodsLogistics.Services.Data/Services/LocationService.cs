using System.Collections.Generic;
using System.Threading.Tasks;
using GoodsLogistics.Auth.Providers.Interfaces;
using GoodsLogistics.Models.DTO;
using GoodsLogistics.Models.DTO.Location;
using GoodsLogistics.Services.Data.Services.Interfaces;

namespace GoodsLogistics.Services.Data.Services
{
    public class LocationService : ILocationService
    {
        private readonly IApiServiceProvider _apiServiceProvider;
        private readonly IResponseService _responseService;

        public LocationService(
            IApiServiceProvider apiServiceProvider,
            IResponseService responseService)
        {
            _apiServiceProvider = apiServiceProvider;
            _responseService = responseService;
        }

        public async Task<ServiceResponseModel<List<CountryModel>>> GetCountries()
        {
            var url = $"https://localhost:44380/countries";
            var httpResponse = await _apiServiceProvider.GetAsync(
                url,
                true);

            var result = await _responseService.CreateResponse<List<CountryModel>>(httpResponse);
            return result;
        }

        public async Task<ServiceResponseModel<List<RegionModel>>> GetRegionsByCountryId(int countryId)
        {
            var url = $"https://localhost:44380/countries/{countryId}/regions";
            var httpResponse = await _apiServiceProvider.GetAsync(
                url,
                true);

            var result = await _responseService.CreateResponse<List<RegionModel>>(httpResponse);
            return result;
        }

        public async Task<ServiceResponseModel<List<CityModel>>> GetCitiesByRegionId(int regionId)
        {
            var url = $"https://localhost:44380/countries/regions/{regionId}";
            var httpResponse = await _apiServiceProvider.GetAsync(
                url,
                true);

            var result = await _responseService.CreateResponse<List<CityModel>>(httpResponse);
            return result;
        }
    }
}
