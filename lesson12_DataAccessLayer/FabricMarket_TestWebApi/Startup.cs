using FabricMarket_DAL;
using FabricMarket_TestWebApi.Contracts.Exceptions;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ILogger = Serilog.ILogger;

namespace FabricMarket_TestWebApi
{
    public static class Startup
    {
        public static void RegisterDAL(IServiceCollection services)
        {
            services.AddNpgsql<DbContext>("host=localhost;port=5432;database=FabricMarket;Username=postgres;Password=123123");
            if (!TestConnection(services))
            {
                throw new DbConnectionException("Test of DB connection failed!");
            }

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


        private static bool TestConnection(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var logger = provider.GetService<ILogger>();
            logger.Information("Testing the DB connection...");
            
            var context = provider.GetRequiredService<DbContext>();

            try
            {
                var createdAnew = context.Database.EnsureCreated();
                if (createdAnew)
                {
                    logger.Information("Successfully created the DB");
                }
                else
                {
                    logger.Information("The DB is already there");
                }
            }
            catch (Exception ex)
            {
                logger.Information("EnsureCreated failed!");
                logger.Information(ex.ToString());
                return false;
            }
            return true;
        }

    }
}
