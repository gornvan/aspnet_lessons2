using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using ILogger = Serilog.ILogger;

namespace FabricMarket_TestWebApi.RequestFilters
{
	public class ExceptionLoggingHandler : IExceptionHandler
	{
		private ILogger _logger;

		public ExceptionLoggingHandler(ILogger logger) {
			_logger = logger;
		}

		public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
		{
			// TODO this is not yet reaching the client, why?
			await httpContext.Response.WriteAsync("The server has faced an unexpected problem, please try again or contact the administrator");

			if (exception is not ValidationException)
			{
				_logger.Error(exception, string.Empty);
			}

			return false;
		}
	}
}
