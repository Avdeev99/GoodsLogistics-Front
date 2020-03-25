using AutoMapper;
using GoodsLogistics.Models.DTO.UserCompany;
using GoodsLogistics.ViewModels.DTO;

namespace GoodsLogistics.Automapper.Profiles
{
    public class UserCompanyProfile : Profile
    {
        public UserCompanyProfile()
        {
            CreateMap<LoginViewModel, UserCompanyLoginRequestModel>().ReverseMap();

            CreateMap<RegisterViewModel, UserCompanyCreateRequestModel>().ReverseMap();
        }
    }
}
