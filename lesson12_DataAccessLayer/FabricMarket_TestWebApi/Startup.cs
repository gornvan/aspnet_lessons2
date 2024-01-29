using FabricMarket_DAL;
using System.Data.Entity;
using System.Data.SqlClient;

namespace FabricMarket_TestWebApi
{
    public static class Startup
    {
        public static void RegisterDAL(IServiceCollection services)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.Password = "123123";
            builder.UserID = "postgres";
            builder.DataSource = "localhost,5432";

            builder.InitialCatalog = "FabricMarket";

            var connectionString = builder.ConnectionString;

            services.AddNpgsql(connectionString);

            services.AddScoped<IUnitOfWork>(prov =>
            {
                var context = prov.GetRequiredService<DbContext>();
                return new UnitOfWork(context);
            });
        }

        private static bool TestConnection(DbContext context)
        {
            return context.Database.CreateIfNotExists();
        }

    }
}
