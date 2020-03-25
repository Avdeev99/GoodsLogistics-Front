using System;

namespace GoodsLogistics.Models.DTO.Objective
{
    public class ObjectiveUpdateRequestModel
    {
        public string ReceiverCompanyId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
