using System.Threading.Tasks;
using GoodsLogistics.Services.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoodsLogistics.Web.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<string> GetCountries()
        {
            var serviceResponse = await _locationService.GetCountries();
            if (!serviceResponse.IsSuccess)
            {
                return null;
            }

            var result = JsonConvert.SerializeObject(serviceResponse.Data);
            return result;
        }

        public async Task<string> GetRegionsByCountryId(int countryId)
        {
            var serviceResponse = await _locationService.GetRegionsByCountryId(countryId);
            if (!serviceResponse.IsSuccess)
            {
                return null;
            }

            var result = JsonConvert.SerializeObject(serviceResponse.Data);
            return result;
        }

        public async Task<string> GetCitiesByRegionId(int regionId)
        {
            var serviceResponse = await _locationService.GetCitiesByRegionId(regionId);
            if (!serviceResponse.IsSuccess)
            {
                return null;
            }

            var result = JsonConvert.SerializeObject(serviceResponse.Data);
            return result;
        }
    }
}