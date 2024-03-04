using FabricMarket_DAL;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ILogger = Serilog.ILogger;

namespace FabricMarket_TestWebApi
{
    public static class FabricMarket_TestWebApi_ModuleHead
    {

        internal static void AddServices(WebApplicationBuilder builder)
        {
            AddSerilog(builder);
            RegisterDAL(builder);
        }


        public static void RegisterDAL(WebApplicationBuilder builder)
        {
            var services = builder.Services;

            var connectionString = builder.Configuration.GetConnectionString("Default");
            services.AddTransient<DbContextOptions<FabricMarketDbContext>>(provider =>
            {
                var builder = new DbContextOptionsBuilder<FabricMarketDbContext>();
                builder.UseNpgsql(connectionString);
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
            var loggingDir = builder.Configuration.GetSection("SerilogConfig")["LoggingDir"] ?? "./";
            var logFilePath = Path.Combine(loggingDir, "log.txt");

            var loggerConfig = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Month,
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
