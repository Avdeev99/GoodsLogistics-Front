using System;
using System.Collections.Generic;
using System.Text;
using GoodsLogistics.Models.DTO.Objective;
using GoodsLogistics.Models.DTO.UserCompany;
using GoodsLogistics.Models.Enums;

namespace GoodsLogistics.ViewModels.DTO
{
    public class RequestViewModel
    {
        public string RequestId { get; set; }

        public ObjectiveModel Objective { get; set; }

        public string ObjectiveId { get; set; }

        public string CompanyId { get; set; }

        public UserCompanyModel UserCompany { get; set; }

        public RequestStatus Status { get; set; }

    }
}
