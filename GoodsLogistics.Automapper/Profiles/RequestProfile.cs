using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using GoodsLogistics.Models.DTO.Request;
using GoodsLogistics.ViewModels.DTO;

namespace GoodsLogistics.Automapper.Profiles
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<RequestModel, RequestViewModel>().ReverseMap();
            CreateMap<RequestUpdateModel, RequestUpdateViewModel>().ReverseMap();
        }
    }
}
