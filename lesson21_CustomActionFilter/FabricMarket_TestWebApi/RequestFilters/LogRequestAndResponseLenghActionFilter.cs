using Microsoft.AspNetCore.Mvc.Filters;

namespace FabricMarket_TestWebApi.RequestFilters
{
    public class LogRequestAndResponseLenghActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var msg = $"Request Length: {context.HttpContext.Request.ContentLength}";

            Console.WriteLine(msg);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // actually need to use ResultFilter to handle differend types of results and possibly many switches of those types.
            var msg = $"Response Length: {context.HttpContext.Response.ContentLength}";

            Console.WriteLine(msg);
        }
    }
}
