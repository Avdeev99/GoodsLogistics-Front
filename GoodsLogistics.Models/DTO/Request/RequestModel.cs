using GoodsLogistics.Models.DTO.Objective;
using GoodsLogistics.Models.DTO.UserCompany;
using GoodsLogistics.Models.Enums;

namespace GoodsLogistics.Models.DTO.Request
{
    public class RequestModel
    {
        public string RequestId { get; set; }

        public ObjectiveModel Objective { get; set; }

        public string ObjectiveId { get; set; }

        public string CompanyId { get; set; }

        public UserCompanyModel UserCompany { get; set; }

        public RequestStatus Status { get; set; }
    }
}
