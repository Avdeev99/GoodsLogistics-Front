using System.Threading.Tasks;
using GoodsLogistics.Models.DTO;
using GoodsLogistics.Models.DTO.UserCompany;

namespace GoodsLogistics.Services.Data.Services.Interfaces
{
    public interface IUserCompanyService
    {
        Task<ServiceResponseModel<UserCompanyModel>> GetUserCompany(string email);

        Task<ServiceResponseModel<UserCompanyModel>> UpdateUserCompany(
            string email,
            UserCompanyUpdateRequestModel updateRequestModel);
    }
}
