using CustomerAPI.ApplicationCore.Contracts.RepositoryInterfaces;
using CustomerAPI.ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepositoryAsync _customerRepositoryAsync;
    public CustomerController(ICustomerRepositoryAsync customerRepository)
    {
        _customerRepositoryAsync = customerRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomer()
    {
        return Ok(await _customerRepositoryAsync.GetAllAsync());
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer(Customer obj)
    {
        try
        {
            var result = await _customerRepositoryAsync.InsertAsync(obj);
            return Ok(result);
        }
        catch (Exception ex)
        { 
            return BadRequest(ex.Message);
        }

    }
}