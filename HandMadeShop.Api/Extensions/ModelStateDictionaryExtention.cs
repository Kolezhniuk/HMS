using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HandMadeShop.Api.Extensions
{
    public static class ModelStateDictionaryExtention
    {
        public static string GetDebugError(this ModelStateDictionary modelState)
        {
            return string.Join(", ", modelState.Values
                .SelectMany(v => v.Errors.Select(e => e.ErrorMessage)));
        }
    }
}