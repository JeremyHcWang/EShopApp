using CustomerAPI.ApplicationCore.Contracts.RepositoryInterfaces;
using CustomerAPI.ApplicationCore.Entities;
using CustomerAPI.ApplicationCore.Models.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepositoryAsync _customerRepository;
    public CustomerController(ICustomerRepositoryAsync customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _customerRepository.GetAllAsync());
    }

    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetCustomerById(int customerId)
    {
        var customer = await _customerRepository.GetByIdAsync(customerId);
        if (customer == null)
        {
            return NotFound($"Customer with ID {customerId} was not found.");
        }
        var response = new CustomerResponseModel()
        {
            Id = customer.CustomerId,
            Name = customer.Name,
            Phone = customer.Phone
        };
        return Ok(response);
    }
    
    [HttpGet("bycity/{city}")]
    public async Task<IActionResult> GetCustomerByCity(string city)
    {
        var customers = await _customerRepository.GetCustomerByCityAsync(city);
        var response = customers.Select(c => new CustomerResponseModel()
        {
            Id = c.CustomerId,
            Name = c.Name,
            Phone = c.Phone
        });

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer(Customer obj)
    {
        try
        {
            var result = await _customerRepository.InsertAsync(obj);
            return Ok(result);
        }
        catch (Exception ex)
        { 
            return BadRequest(ex.Message);
        }

    }
}