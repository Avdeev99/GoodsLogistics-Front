using System.Threading.Tasks;
using GoodsLogistics.Models.DTO.UserCompany;

namespace GoodsLogistics.Services.Data.Services.Interfaces
{
    public interface IUserCompanyService
    {
        Task<UserCompanyModel> GetUserCompany(string id);
    }
}
