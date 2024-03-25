using CustomerAPI.ApplicationCore.Entities;

namespace CustomerAPI.ApplicationCore.Contracts.RepositoryInterfaces;

public interface ICustomerRepositoryAsync : IRepositoryAsync<Customer>
{
    Task<IEnumerable<Customer>> GetCustomerByCityAsync(string city);
}