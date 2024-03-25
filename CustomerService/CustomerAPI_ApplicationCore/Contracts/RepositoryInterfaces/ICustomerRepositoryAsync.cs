using CustomerAPI.ApplicationCore.Entities;
using CustomerAPI.ApplicationCore.Models.Response;

namespace CustomerAPI.ApplicationCore.Contracts.RepositoryInterfaces;

public interface ICustomerRepositoryAsync : IRepositoryAsync<Customer>
{
    Task<IEnumerable<Customer>> GetCustomerByCityAsync(string city);
}