using System.ComponentModel.DataAnnotations;
using GoodsLogistics.Localization.Resources;
using GoodsLogistics.Models.DTO.Location;
using GoodsLogistics.Models.DTO.UserCompany;

namespace GoodsLogistics.ViewModels.DTO
{
    public class OfficeViewModel
    {
        public string OfficeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "Required")]
        [MinLength(2, ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "MinLength2Symbols")]
        public string Key { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "Required")]
        [MinLength(6, ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "MinLength6Symbols")]
        public string Address { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "Required")]
        public string CityId { get; set; }

        public CityModel City { get; set; }

        public string CompanyId { get; set; }

        public UserCompanyModel Company { get; set; }
    }
}
