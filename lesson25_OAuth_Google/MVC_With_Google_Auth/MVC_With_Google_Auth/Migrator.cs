using Microsoft.EntityFrameworkCore;
using MVC_With_Google_Auth.Data;

namespace MVC_With_Google_Auth
{
    internal static class DBInitializer
    {
        public static void InitializeDB(IServiceProvider provider)
        {
            if (!ApplyMigrations(provider))
            {
                throw new Exception("Could not initialize DB! See errors above.");
            }
        }

        private static bool ApplyMigrations(IServiceProvider provider)
        {

            var scope = provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
