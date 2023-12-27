namespace lesson5_Chain_Of_Responsibility
{
    public class LocalhostActionFilter : IEndpointFilter
    {
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
