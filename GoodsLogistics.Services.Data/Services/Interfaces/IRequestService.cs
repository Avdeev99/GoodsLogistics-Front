using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GoodsLogistics.Models.DTO;
using GoodsLogistics.Models.DTO.Office;
using GoodsLogistics.Models.DTO.Request;

namespace GoodsLogistics.Services.Data.Services.Interfaces
{
    public interface IRequestService
    {
        Task<ServiceResponseModel<List<RequestModel>>> GetRequests();

        Task<ServiceResponseModel<List<RequestModel>>> GetRequestsByCompanyId(string id);

        Task<ServiceResponseModel<RequestModel>> GetRequestById(string id);

        Task<ServiceResponseModel<RequestModel>> CreateRequest(RequestModel createRequestModel);

        Task<ServiceResponseModel<RequestModel>> UpdateRequest(
            string id,
            RequestUpdateModel updateRequestModel);

        Task DeleteRequest(string id);
    }
}
