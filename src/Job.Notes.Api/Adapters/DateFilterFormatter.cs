using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Job.Notes.Api.Adapters;

public class DateFilterFormatter: Attribute, IActionFilter
{
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                objectResult.Value = FormatDates(objectResult.Value);
            }
        }
        
        public void OnActionExecuting(ActionExecutingContext context) { }

        private object FormatDates(object value)
        {
            if (value == null) return null;

            var settings = new JsonSerializerSettings
            {
                Converters = new[] { new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" } },
            };

            return JsonConvert.SerializeObject(value, settings);
        }
}