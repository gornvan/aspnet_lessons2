using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
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
