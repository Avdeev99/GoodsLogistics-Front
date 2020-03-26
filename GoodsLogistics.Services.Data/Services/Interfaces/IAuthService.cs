using System.Threading.Tasks;
using GoodsLogistics.Models.DTO;
using GoodsLogistics.Models.DTO.UserCompany;

namespace GoodsLogistics.Services.Data.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResultModel> RegisterAsync(UserCompanyCreateRequestModel createRequestModel);

        Task<AuthResultModel> LoginAsync(UserCompanyLoginRequestModel createRequestModel);
    }
}
