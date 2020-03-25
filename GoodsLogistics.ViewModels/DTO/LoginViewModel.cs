using System.ComponentModel.DataAnnotations;
using GoodsLogistics.Localization.Resources;

namespace GoodsLogistics.ViewModels.DTO
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "Required")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
