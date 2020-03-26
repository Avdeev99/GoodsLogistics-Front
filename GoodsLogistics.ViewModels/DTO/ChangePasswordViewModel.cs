using System.ComponentModel.DataAnnotations;
using GoodsLogistics.Localization.Resources;

namespace GoodsLogistics.ViewModels.DTO
{
    public class ChangePasswordViewModel
    {
        public string CompanyId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "Required")]
        [MinLength(6, ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "MinLength6Symbols")]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "PasswordCompareMessage")]
        public string ConfirmPassword { get; set; }
    }
}
