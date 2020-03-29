using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GoodsLogistics.Auth.Providers.Interfaces
{
    public interface IApiServiceProvider
    {
        Task<HttpResponseMessage> GetAsync(
            string url,
            bool isAuthRequired,
            CancellationToken cancellationToken = default);

        Task<HttpResponseMessage> PatchAsync<TBody>(
            string url,
            TBody requestBody,
            bool isAuthRequired,
            CancellationToken cancellationToken = default) where TBody : class;

        Task<HttpResponseMessage> PostAsync<TBody>(
            string url,
            TBody requestBody,
            bool isAuthRequired,
            CancellationToken cancellationToken = default) where TBody : class;

        Task<HttpResponseMessage> DeleteAsync(
            string url,
            bool isAuthRequired,
            CancellationToken cancellationToken = default);
    }
}
