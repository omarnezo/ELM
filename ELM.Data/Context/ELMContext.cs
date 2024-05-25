using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ELM.Data.Context
{
    public class ELMContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;


        public ELMContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ELMConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
