using CustomerAPI_Infrastructure.Data;
using CustomerAPI.ApplicationCore.Contracts.RepositoryInterfaces;
using CustomerAPI.ApplicationCore.Entities;

namespace CustomerAPI_Infrastructure.Repositories;

public class CustomerRepositoryAsync : BaseRepositoryAsync<Customer>, ICustomerRepositoryAsync
{
    public CustomerRepositoryAsync(EShopDbContext context) : base(context)
    {
    }
}