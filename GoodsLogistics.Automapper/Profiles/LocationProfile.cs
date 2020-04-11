using AutoMapper;
using GoodsLogistics.Models.DTO.Location;
using GoodsLogistics.Models.DTO.Office;
using GoodsLogistics.ViewModels.DTO;

namespace GoodsLogistics.Automapper.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationModel, LocationViewModel>().ReverseMap();
            CreateMap<OfficeModel, LocationModel>().ReverseMap();
        }
    }
}
