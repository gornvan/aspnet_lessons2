using FabricMarket_BLL;
using FabricMarket_TestWebApi.RequestFilters;

namespace FabricMarket_TestWebApi
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

            builder.Services.AddTransient<ExceptionLoggingHandler, ExceptionLoggingHandler>();
            builder.Services.AddExceptionHandler<ExceptionLoggingHandler>();

            FabricMarket_TestWebApi_ModuleHead.AddServices(builder);

            FabricMarket_BLL_ModuleHead.RegisterModule(builder.Services);

            var app = builder.Build();

            DBInitializer.InitializeDB(app.Services);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

			// seems to be a bug, not calling the /Error endpoint
			// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-8.0#iexceptionhandler
			app.UseExceptionHandler("/Error");

            //app.Map("/Error", async context =>
            //{
			//	await context.Response.WriteAsync("The server has faced an unexpected problem, please try again or contact the administrator");
			//	context.Response.StatusCode = 500;
			//});

			//app.UseExceptionHandler(new ExceptionHandlerOptions
			//{
			//    ExceptionHandler = context => {
			//        context.Response.StatusCode = 500;
			//        return Task.CompletedTask;
			//    }
			//});

			app.MapControllers();

            // useful when building an MVC application, not API:
			//app.UseEndpoints(endpoints =>
			//{
			//	endpoints.MapControllerRoute(
			//	name: "default",
			//	pattern: "/api/{controller}/{action}/{id?}");
			//});

			app.Run();
        }
    }
}
