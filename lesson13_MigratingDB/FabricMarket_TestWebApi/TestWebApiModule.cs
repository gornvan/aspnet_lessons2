using FabricMarket_DAL;
using FabricMarket_TestWebApi.Contracts.Exceptions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ILogger = Serilog.ILogger;

namespace FabricMarket_TestWebApi
{
    public static class TestWebApiModule
    {

        internal static void AddServices(WebApplicationBuilder builder)
        {
            AddSerilog(builder);
            RegisterDAL(builder.Services);
        }


        public static void RegisterDAL(IServiceCollection services)
        {
            services.AddTransient<DbContextOptions<FabricMarketDbContext>>(provider =>
            {
                var builder = new DbContextOptionsBuilder<FabricMarketDbContext>();
                builder.UseNpgsql("host=localhost;port=5432;database=FabricMarket;Username=postgres;Password=123123");
                return builder.Options;
            });

            services.AddScoped<DbContext, FabricMarketDbContext>();

            services.AddScoped<IUnitOfWork>(prov =>
            {
                var context = prov.GetRequiredService<DbContext>();
                return new UnitOfWork(context);
            });
        }

        internal static void AddSerilog(WebApplicationBuilder builder)
        {
            var loggerConfig = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Month,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}");

            if (builder.Environment.IsDevelopment())
            {
                loggerConfig = loggerConfig.MinimumLevel.Debug();
            }
            else
            {
                loggerConfig = loggerConfig.MinimumLevel.Warning();
            }

            var logger = loggerConfig.CreateLogger();

            builder.Services.AddSingleton<ILogger>(logger);
        }
    }
}
