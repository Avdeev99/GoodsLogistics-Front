using System.Collections.Generic;
using System.Threading.Tasks;
using GoodsLogistics.Models.DTO;
using GoodsLogistics.Models.DTO.Office;

namespace GoodsLogistics.Services.Data.Services.Interfaces
{
    public interface IOfficeService
    {
        Task<ServiceResponseModel<List<OfficeModel>>> GetOffices();

        Task<ServiceResponseModel<OfficeModel>> GetOfficeByKey(string key);

        Task<ServiceResponseModel<OfficeModel>> CreateOffice(OfficeModel createRequestModel);

        Task<ServiceResponseModel<OfficeModel>> UpdateOffice(
            string key,
            OfficeUpdateRequestModel updateRequestModel);

        Task DeleteOffice(string key);
    }
}
