using Dapper;
using Npgsql;
using System.Data;

namespace POC.ApiPostgreDapper.Services
{
    public class DbService : IDbService
    {
        private readonly IDbConnection _dbConnection;

        public DbService(IConfiguration configuration)
        {
            _dbConnection = new NpgsqlConnection(configuration.GetConnectionString("EmployeeDB"));
        }

        public async Task<int> ExecuteAsync(string sql, object parameters)
        {
            int result = await _dbConnection.ExecuteAsync(sql, parameters);

            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string sql, object parameters)
        {
            IEnumerable<T> result = (await _dbConnection.QueryAsync<T>(sql, parameters)).ToList();

            return result;
        }

        public async Task<T?> GetAsync<T>(string sql, object parameters)
        {
            T? result;

            result = await _dbConnection.QueryFirstOrDefaultAsync<T>(sql, parameters);

            return result;
        }
    }
}
