using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GoodsLogistics.Localization.Resources;
using GoodsLogistics.Models.DTO;
using GoodsLogistics.Models.DTO.UserCompany;
using GoodsLogistics.Models.Enums;

namespace GoodsLogistics.ViewModels.DTO
{
    public class ObjectiveUpdateRequestViewModel
    {
        public string ReceiverCompanyId { get; set; }

        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "Required")]
        public DateTime OrderDate { get; set; }

        public OrderFrequency Frequency { get; set; }

        public List<UserCompanyModel> Companies { get; set; }

        public List<string> Rules { get; set; }
    }
}
