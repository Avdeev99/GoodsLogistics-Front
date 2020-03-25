using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GoodsLogistics.Models.DTO.UserCompany;
using GoodsLogistics.Services.Data.Services.Interfaces;
using Newtonsoft.Json;

namespace GoodsLogistics.Services.Data.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> RegisterAsync(UserCompanyCreateRequestModel createRequestModel)
        {
            var jsonModel = JsonConvert.SerializeObject(createRequestModel);
            HttpContent content = new StringContent(jsonModel);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.PostAsync("https://localhost:44380/register", content);
            var accessToken = await response.Content.ReadAsStringAsync();

            return accessToken;
        }

        public async Task<string> LoginAsync(UserCompanyLoginRequestModel loginRequestModel)
        {
            var jsonModel = JsonConvert.SerializeObject(loginRequestModel);
            HttpContent content = new StringContent(jsonModel);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.PostAsync("https://localhost:44380/login", content);
            var accessToken = await response.Content.ReadAsStringAsync();

            return accessToken;
        }
    }
}
