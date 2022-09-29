using System.Data.SqlClient;

namespace schoolapi.Infrasctructure
{
    public static class Migration
    {
        public static void DbMigration(this IConfiguration configuration)
        {
            try
            {
                var cnx = new SqlConnection(configuration.GetConnectionString("SqlServer"));
                var evolve = new Evolve.Evolve(cnx)
                {
                    IsEraseDisabled = true,
                    CommandTimeout = 600,
                    Locations = new[] { "Scripts" },
                };

                evolve.Migrate();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}