
using lesson8_WebApi.Middlewares;
using System.Reflection;

namespace lesson8_WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            ApplyApiVersionRoutePrefix(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static void ApplyApiVersionRoutePrefix(WebApplication app)
        {
            var appVersion = Assembly.GetExecutingAssembly().GetName().Version;
            var pathPrefix = $"/api/{appVersion}";
            app.UseMiddleware<GlobalRoutePrefixMiddleware>(pathPrefix);
            app.UsePathBase(pathPrefix);
        }
    }
}
