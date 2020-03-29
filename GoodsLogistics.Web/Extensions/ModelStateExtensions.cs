using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GoodsLogistics.Web.Extensions
{
    public static class ModelStateExtensions
    {
        public static void AddModelErrors(
            this ModelStateDictionary modelState, 
            Dictionary<string, string> errors)
        {
            Parallel.ForEach(errors, error =>
            {
                modelState.AddModelError(error.Key, error.Value);
            });
        }
    }
}
