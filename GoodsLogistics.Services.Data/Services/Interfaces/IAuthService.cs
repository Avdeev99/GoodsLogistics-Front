using System.Threading.Tasks;
using GoodsLogistics.Models.DTO.UserCompany;

namespace GoodsLogistics.Services.Data.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(UserCompanyCreateRequestModel createRequestModel);

        Task<string> LoginAsync(UserCompanyLoginRequestModel createRequestModel);
    }
}
