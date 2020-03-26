using System.Collections.Generic;
using GoodsLogistics.Models.DTO.UserCompany;

namespace GoodsLogistics.Models.DTO
{
    public class AuthResultModel
    {
        public string JwtToken { get; set; }

        public UserCompanyModel UserCompany { get; set; }

        public Dictionary<string, string> Errors { get; set; }

        public bool IsAuthorized { get; set; }
    }
}
