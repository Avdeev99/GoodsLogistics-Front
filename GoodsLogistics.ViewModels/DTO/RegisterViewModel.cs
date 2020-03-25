using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GoodsLogistics.Localization.Resources;

namespace GoodsLogistics.ViewModels.DTO
{
    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "Required")]
        [Display(Name = "Full Name")]
        [MinLength(2, ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "MinLength2Symbols")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "Required")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "EmailType")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "Required")]
        [MinLength(6, ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "MinLength6Symbols")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "PasswordCompareMessage")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
