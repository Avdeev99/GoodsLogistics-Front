using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GoodsLogistics.Localization.Resources;
using GoodsLogistics.Models.DTO.Office;
using GoodsLogistics.Models.DTO.UserCompany;

namespace GoodsLogistics.ViewModels.DTO
{
    public class UserCompanyViewModel
    {
        public string CompanyId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "Required")]
        [Display(Name = "Company Name")]
        [MinLength(2, ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "MinLength2Symbols")]
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<OfficeModel> Offices { get; set; }

        public RoleModel Role { get; set; }

        public string RoleId { get; set; }
    }
}
