namespace POC.ApiPostgreDapper.Services
{
    public interface IDbService
    {
        Task<T?> GetAsync<T>(string sql, object parameters);
        Task<IEnumerable<T>> GetAllAsync<T>(string sql, object parameters);
        Task<int> ExecuteAsync(string sql, object parameters);
    }
}
