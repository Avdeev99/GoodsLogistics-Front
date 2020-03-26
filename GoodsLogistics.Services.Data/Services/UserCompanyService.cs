using System;
using System.Net.Http;
using System.Threading.Tasks;
using GoodsLogistics.Models.DTO.UserCompany;
using GoodsLogistics.Services.Data.Services.Interfaces;
using Newtonsoft.Json;

namespace GoodsLogistics.Services.Data.Services
{
    public class UserCompanyService : IUserCompanyService
    {
        private readonly HttpClient _httpClient;

        public UserCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserCompanyModel> GetUserCompany(string email)
        {
            var response = await _httpClient.GetAsync($"https://localhost:44380/users/{email}");
            var responseStr = await response.Content.ReadAsStringAsync();
            var userCompany = JsonConvert.DeserializeObject<UserCompanyModel>(responseStr);
            return userCompany;
        }
    }
}
