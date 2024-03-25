namespace OrderAPI_ApplicationCore.Contracts.RepositoryInterfaces;

public interface IRepositoryAsync<T> where T : class
{
    Task<int> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);
    Task<List<T>> GetAllAsync();
    ValueTask<T?> GetByIdAsync(int id);
}