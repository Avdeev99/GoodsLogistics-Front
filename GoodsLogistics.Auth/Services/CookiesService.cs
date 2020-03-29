using System;
using System.Collections.Generic;
using System.Text;
using GoodsLogistics.Auth.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GoodsLogistics.Auth.Services
{
    public class CookiesService : ICookiesService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookiesService(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public void SetCookie(
            string key, 
            string value, 
            int? expireTimeInSeconds = null)
        {
            var option = new CookieOptions
            {
                Expires = expireTimeInSeconds.HasValue ? DateTime.Now.AddSeconds(expireTimeInSeconds.Value) : DateTime.Now.AddHours(1)
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, option);
        }

        public string GetCookieByKey(string key)
        {
            return _httpContextAccessor.HttpContext.Request.Cookies[key];
        }

        public void RemoveCookie(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }
    }
}
