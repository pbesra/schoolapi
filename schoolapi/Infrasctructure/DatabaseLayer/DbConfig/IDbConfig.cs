using System.Data;

namespace schoolapi.Infrasctructure.DatabaseLayer.DbConfig
{
    public interface IDBConfig
    {
        string GetConnectionString();

        IDbConnection GetConnection();
    }
}