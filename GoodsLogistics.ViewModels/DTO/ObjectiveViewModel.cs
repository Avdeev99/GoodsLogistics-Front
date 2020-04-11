using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using GoodsLogistics.Localization.Resources;
using GoodsLogistics.Models.DTO;
using GoodsLogistics.Models.DTO.Location;
using GoodsLogistics.Models.DTO.UserCompany;
using GoodsLogistics.Models.Enums;

namespace GoodsLogistics.ViewModels.DTO
{
    public class ObjectiveViewModel : IValidatableObject
    {
        public string ObjectiveId { get; set; }

        public string SenderCompanyId { get; set; }

        public UserCompanyModel SenderCompany { get; set; }

        public string ReceiverCompanyId { get; set; }

        public UserCompanyModel ReceiverCompany { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
        ErrorMessageResourceName = "Required")]
        public DateTime OrderDate { get; set; }

        public OrderFrequency Frequency { get; set; }

        public GoodModel Good { get; set; }

        public LocationViewModel Location { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources),
            ErrorMessageResourceName = "Required")]
        public decimal Price { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            if (OrderDate.ToUniversalTime() < DateTime.UtcNow)
            {
                string message = null;

                if (CultureInfo.CurrentCulture.Name == "uk")
                {
                    message = "Дата замовлення повинна перевищувати поточний час";
                }

                if (CultureInfo.CurrentCulture.Name == "en")
                {
                    message = "Order date must be greater than current time";
                }

                var invalidMembers = new List<string> {nameof(OrderDate)};
                var error = new ValidationResult(message, invalidMembers);
                result.Add(error);
            }

            if (Frequency != OrderFrequency.None && EndDate.Date < OrderDate)
            {
                string message = null;

                if (CultureInfo.CurrentCulture.Name == "uk")
                {
                    message = "Кінцева дата повинна бути більшою або рівною датою замовлення";
                }

                if (CultureInfo.CurrentCulture.Name == "en")
                {
                    message = "End date must be greater or equal order date";
                }

                var invalidMembers = new List<string> { nameof(OrderDate) };
                var error = new ValidationResult(message, invalidMembers);
                result.Add(error);
            }

            return result;
        }
    }
}
