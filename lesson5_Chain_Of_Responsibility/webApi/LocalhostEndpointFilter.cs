namespace lesson5_Chain_Of_Responsibility
{
    public class LocalhostEndpointFilter : IEndpointFilter
    {
        // THIS CODE IS CLONED IN THE MVC SYSTEM (../mvc)
        // TODO: pull it into a nuget package
        public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            // this is not a reliable way to check if the client is localhost!
            var clientIsLocalhost = context.HttpContext.Connection.RemoteIpAddress.ToString() == "127.0.0.1";

            if (clientIsLocalhost)
            {
                throw new ClientIsLocalhostException("The client is not from localhost!");
            }

            return next(context);
        }
    }
}
