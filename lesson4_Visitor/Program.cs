var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

/// REAL-LIFE VISITOR EXAMPLE
// This is an example of a VISITOR pattern.
// The vising method accepts the "visit object" and MODIFIES(mutates) it
builder.Services.AddCors(
    // THE VISITOR BODY
    options =>
    {
        options.AddPolicy(
            name: "Just a name",
            // ANOTHER VISITOR BODY INSIDE
            policy =>
            {
                policy.WithOrigins("http://example.com",
                                    "http://www.contoso.com");
            }
        );
    }
);

// A more simple approach, which doesn't allow the configured system to control the configuration:
//  builder.Services.Cors.Policies.Add(new
//  [
//      new Policy { 
//          Name = "Just a name",
//          Origins = ["http://example.com", "http://www.contoso.com"]
//      }
//  ]);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
