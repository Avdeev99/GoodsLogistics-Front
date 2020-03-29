using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GoodsLogistics.Models.DTO;
using GoodsLogistics.Services.Data.Services.Interfaces;
using Newtonsoft.Json;

namespace GoodsLogistics.Services.Data.Services
{
    public class ResponseService : IResponseService
    {
        public async Task<ServiceResponseModel<T>> CreateResponse<T>(HttpResponseMessage httpResponse) where T : class
        {
            var httpResponseBody = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<T>(httpResponseBody);
                var result = new ServiceResponseModel<T>(data);
                return result;
            }

            var errors = JsonConvert.DeserializeObject<Dictionary<string, string>>(httpResponseBody);
            var badResult = new ServiceResponseModel<T>(errors);
            return badResult;
        }
    }
}
