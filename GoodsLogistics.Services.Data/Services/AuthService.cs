using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GoodsLogistics.Models.DTO;
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

        public async Task<AuthResultModel> RegisterAsync(UserCompanyCreateRequestModel createRequestModel)
        {
            var jsonModel = JsonConvert.SerializeObject(createRequestModel);
            HttpContent content = new StringContent(jsonModel);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.PostAsync("https://localhost:44380/register", content);
            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<AuthResultModel>(responseString);
            return result;
        }

        public async Task<AuthResultModel> LoginAsync(UserCompanyLoginRequestModel loginRequestModel)
        {
            var jsonModel = JsonConvert.SerializeObject(loginRequestModel);
            HttpContent content = new StringContent(jsonModel);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.PostAsync("https://localhost:44380/login", content);
            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<AuthResultModel>(responseString);
            return result;
        }
    }
}
