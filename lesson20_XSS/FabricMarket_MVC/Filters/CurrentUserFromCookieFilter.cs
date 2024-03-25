using Microsoft.AspNetCore.Mvc.Filters;

namespace FabricMarket_MVC.Filters
{
    public class CurrentUserFromCookieFilterAttribute : ActionFilterAttribute
    {
        public const string UserNameContextItemKey = "CurrentUserNameDeclaredByBrowser";
        public const string UserNameCookieKey = "Email";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Cookies.TryGetValue(UserNameCookieKey, out var userName))
            {
                context.HttpContext.Items[UserNameContextItemKey] = userName;
            }
        }
    }
}
