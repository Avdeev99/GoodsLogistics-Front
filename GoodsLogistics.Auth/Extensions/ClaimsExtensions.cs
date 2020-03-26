using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using GoodsLogistics.Models.DTO.UserCompany;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace GoodsLogistics.Auth.Extensions
{
    public static class ClaimsExtensions
    {
        public static ClaimsPrincipal CreatePrincipal(IEnumerable<Claim> claims)
        {
            return new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
        }

        public static IEnumerable<Claim> GenerateClaims(UserCompanyModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.CompanyId),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email)
            };

            return claims;
        }
    }
}
