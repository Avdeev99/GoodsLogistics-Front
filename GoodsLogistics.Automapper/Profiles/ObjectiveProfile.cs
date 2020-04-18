using System.Collections.Generic;
using AutoMapper;
using GoodsLogistics.Models.DTO;
using GoodsLogistics.Models.DTO.Objective;
using GoodsLogistics.ViewModels.DTO;

namespace GoodsLogistics.Automapper.Profiles
{
    public class ObjectiveProfile : Profile
    {
        public ObjectiveProfile()
        {
            CreateMap<ObjectiveModel, ObjectiveViewModel>().ReverseMap();
            
            CreateMap<ObjectiveFilteringModel, ObjectiveFilteringViewModel>().ReverseMap();

            CreateMap<ObjectiveCreateRequestViewModel, ObjectiveModel>()
                .ForMember(dest => dest.Rules, m => m.MapFrom(src => GetRules(src.Rules)));
        }

        private List<RuleModel> GetRules(List<string> rules)
        {
            var result = new List<RuleModel>();

            if (rules == null)
            {
                return result;
            }

            foreach (var item in rules)
            {
                var rule = new RuleModel(item);
                result.Add(rule);
            }

            return result;
        }
    }
}
