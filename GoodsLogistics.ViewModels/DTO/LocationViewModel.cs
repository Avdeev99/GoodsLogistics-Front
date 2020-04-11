using GoodsLogistics.Models.DTO.Location;

namespace GoodsLogistics.ViewModels.DTO
{
    public class LocationViewModel
    {
        public string OfficeKey { get; set; }

        public int CityId { get; set; }

        public CityModel City { get; set; }

        public string Address { get; set; }
    }
}
