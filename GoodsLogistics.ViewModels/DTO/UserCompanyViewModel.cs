using System.Collections.Generic;
using GoodsLogistics.Models.DTO.Office;

namespace GoodsLogistics.ViewModels.DTO
{
    public class UserCompanyViewModel
    {
        public string CompanyId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<OfficeModel> Offices { get; set; }
    }
}
