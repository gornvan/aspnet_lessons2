using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace lesson8_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast?> Get(
            int minTemperatureC,
            int maxTemperatureC,
            int pageSize = 5,
            int pageNumber = 1,
            [FromQuery] string[]? fields = null)
        {
            var unprojectedQuery = Enumerable.Range(1, 1024 * 1024 * 1024 /* Emulating a LARGE source of data which we will not consume in full thanks to Pagination */)
                .Select(index =>
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                // Always filter BEFORE paging
                .Where(forecast =>
                    forecast.TemperatureC >= minTemperatureC
                    &&
                    forecast.TemperatureC <= maxTemperatureC)
                // Always page AFTER filtering
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);

            var projectedQuery = fields == null
                ? unprojectedQuery
                : unprojectedQuery.Select(forecast => MutateObjectToGetProjection(forecast, fields));

            return projectedQuery.ToList();
        }

        private static T? MutateObjectToGetProjection<T>(T? originalObject, string[] fieldNames) where T: class
        {
            if (originalObject == default(T))
            {
                return originalObject;
            }

            var props = originalObject.GetType().GetProperties().Where(p => p.IsPubliclyWritable());

            foreach (var prop in props)
            {
                if (!fieldNames.Any(
                    fn => prop.Name.Equals(fn, StringComparison.OrdinalIgnoreCase))
                )
                {
                    prop.SetValue(originalObject, null);
                }
            }
            return originalObject;
        }


        [Produces("application/json", new[] { "text/plain" })]
        [HttpGet(template: "{daysAhead}", Name = "GetWeathForecastForConcreteDayAhead")]
        public IActionResult Get(int daysAhead)
        {
            var forecast = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(daysAhead)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };

            var accept = Request.GetTypedHeaders().Accept;
            switch (accept[0].MediaType.ToString())
            {
                case "application/json":
                case "*/*":
                default:
                    return new JsonResult(forecast);

                case "text/plain":
                    return Content(
                        $"""
                        Date: {forecast.Date};
                        The temperature will be {forecast.TemperatureC} Celcius;
                        It will feel {forecast.Summary}.
                        """
                        );
            }
        }
    }
}
