using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using GoodsLogistics.Auth.Constants;
using GoodsLogistics.Auth.Providers.Interfaces;
using GoodsLogistics.Auth.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoodsLogistics.Auth.Providers
{
    public class ApiServiceProvider : IApiServiceProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ICookiesService _cookiesService;

        public ApiServiceProvider(
            HttpClient httpClient, 
            ICookiesService cookiesService)
        {
            _httpClient = httpClient;
            _cookiesService = cookiesService;
        }

        public async Task<HttpResponseMessage> GetAsync(
            string url, 
            bool isAuthRequired, 
            CancellationToken cancellationToken = default)
        {
            if (isAuthRequired)
            {
                UpdateHttpClientWithAuthToken();
            }

            var httpResponse = await _httpClient.GetAsync(url, cancellationToken);
            return httpResponse;
        }

        public async Task<HttpResponseMessage> PatchAsync<TBody>(
            string url, 
            TBody requestBody,
            bool isAuthRequired,
            CancellationToken cancellationToken = default) where TBody : class
        {
            if (isAuthRequired)
            {
                UpdateHttpClientWithAuthToken();
            }

            var jsonModel = JsonConvert.SerializeObject(requestBody);
            HttpContent content = new StringContent(jsonModel);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpResponse = await _httpClient.PatchAsync(url, content, cancellationToken);
            return httpResponse;
        }

        public async Task<HttpResponseMessage> PostAsync<TBody>(
            string url, 
            TBody requestBody, 
            bool isAuthRequired,
            CancellationToken cancellationToken = default) where TBody : class
        {
            if (isAuthRequired)
            {
                UpdateHttpClientWithAuthToken();
            }

            var jsonModel = JsonConvert.SerializeObject(requestBody);
            HttpContent content = new StringContent(jsonModel);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpResponse = await _httpClient.PostAsync(url, content, cancellationToken);
            return httpResponse;
        }

        public async Task<HttpResponseMessage> DeleteAsync(
            string url,
            bool isAuthRequired,
            CancellationToken cancellationToken = default)
        {
            if (isAuthRequired)
            {
                UpdateHttpClientWithAuthToken();
            }

            var httpResponse = await _httpClient.DeleteAsync(url, cancellationToken);
            return httpResponse;
        }

        private void UpdateHttpClientWithAuthToken()
        {
            var jwtToken = _cookiesService.GetCookieByKey(AuthConstants.JwtToken);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                jwtToken);
        }
    }
}
