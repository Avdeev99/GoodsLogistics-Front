using System;
using System.Collections.Generic;
using System.Text;
using GoodsLogistics.Models.Enums;

namespace GoodsLogistics.ViewModels.DTO
{
    public class ObjectiveFilteringViewModel
    {
        public SortingMethod SortingMethod { get; set; }

        public decimal? PriceFrom { get; set; }

        public decimal? PriceTo { get; set; }

        public int? CountryId { get; set; }

        public int? RegionId { get; set; }

        public int? CityId { get; set; }
    }
}
