using System.Net.Http;
using System.Threading.Tasks;
using GoodsLogistics.Models.DTO;

namespace GoodsLogistics.Services.Data.Services.Interfaces
{
    public interface IResponseService
    {
        Task<ServiceResponseModel<T>> CreateResponse<T>(HttpResponseMessage httpResponse);
    }
}
