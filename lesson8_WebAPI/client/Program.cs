using IO.Swagger.Api;
using IO.Swagger.Client;
using System.Text.Json;

var client = new ApiClient();

var api = new WeatherForecastApi(client);

var forecasts = api.GetWeatherForecast(10, 15, 10, 45, null);

Console.WriteLine(JsonSerializer.Serialize(forecasts));