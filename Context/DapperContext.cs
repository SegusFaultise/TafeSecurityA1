using System.Data;
using System.Data.SqlClient;

namespace SQL_WEB_APPLICATION.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _conConfig;

        private readonly string? _connectionString;

        public DapperContext(IConfiguration conConfig)
        {
            _conConfig = conConfig;
            _connectionString = _conConfig.GetConnectionString("SqlConnection");

        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
