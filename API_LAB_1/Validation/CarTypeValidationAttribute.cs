using API_LAB_1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace API_LAB_1.Validation
{
    public class CarTypeValidationAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var typeRegex = new Regex("^(Electric|Gas|Diesel|Hybrid)");
            Cars? car = context.ActionArguments["car"] as Cars;

            if (car == null || !typeRegex.IsMatch(car.cartype)){

                context.Result = new BadRequestObjectResult(new { typeError = "cartype is not Valid" });

            }
        }
    }
}
