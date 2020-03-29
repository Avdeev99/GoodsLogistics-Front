using System.Collections.Generic;
using System.Threading.Tasks;
using GoodsLogistics.Models.DTO;
using GoodsLogistics.Models.DTO.Location;

namespace GoodsLogistics.Services.Data.Services.Interfaces
{
    public interface ILocationService
    {
        Task<ServiceResponseModel<List<CountryModel>>> GetCountries();

        Task<ServiceResponseModel<List<RegionModel>>> GetRegionsByCountryId(int countryId);

        Task<ServiceResponseModel<List<CityModel>>> GetCitiesByRegionId(int regionId);
    }
}
