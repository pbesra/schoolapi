using System.Data;
using System.Data.SqlClient;

namespace schoolapi.Infrasctructure.DatabaseLayer.DbConfig
{
    public class DbConfig : IDBConfig
    {
        private readonly IConfigurationSection _appConfigurationSection;
        private readonly IConfiguration _configuration;

        public DbConfig(IConfiguration configuration)
        {
            this._configuration = configuration;
            _appConfigurationSection = this._configuration.GetSection("DbConnection");
        }

        public string ServerName => _appConfigurationSection["SqlServerName"];

        public string DatabaseName => _appConfigurationSection["DataBaseName"];

        public string UserName => _configuration["SqlDbUsername"];

        public string Password => _configuration["SqlDbPassword"];

        public string GetConnectionString()
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                PersistSecurityInfo = true,
                DataSource = ServerName,
                UserID = UserName,
                Password = Password,
                InitialCatalog = DatabaseName,
                MaxPoolSize = 500,
                MultipleActiveResultSets = true,
                Encrypt = true,
                ConnectTimeout = 30,
                TrustServerCertificate = true
            };

            return sqlConnectionStringBuilder.ConnectionString;
        }

        public IDbConnection GetConnection()
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder
            {
                PersistSecurityInfo = true,
                DataSource = ServerName,
                UserID = UserName,
                Password = Password,
                InitialCatalog = DatabaseName,
                MaxPoolSize = 500,
                ConnectTimeout = 500,
            };

            return new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
        }
    }
}