using Microsoft.AspNetCore.Mvc.Filters;

namespace lesson5_Chain_Of_Responsibility
{
    public class LocalhostActionFilterAttribute : ActionFilterAttribute
    {
        // THIS CODE IS CLONED IN THE WEB API SYSTEM (../webapi)
        // TODO: pull it into a nuget package
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // this is not a reliable way to check if the client is localhost!
            var clientAddress = context?.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? string.Empty;
            var clientIsLocalhost = clientAddress == "127.0.0.1";

            if (clientIsLocalhost)
            {
                throw new ClientIsLocalhostException("The client is not from localhost!");
            }
        }
    }
}
