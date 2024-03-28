using AutoMapper;
using CustomerAPI.ApplicationCore.Contracts.RepositoryInterfaces;
using CustomerAPI.ApplicationCore.Entities;
using CustomerAPI.ApplicationCore.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepositoryAsync _customerRepository;
    private readonly IMapper _mapper;
    
    public CustomerController(ICustomerRepositoryAsync customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _customerRepository.GetAllAsync());
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        try
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} was not found.");
            }
            // use AutoMapper to replace manual mapping
            var customerResult = _mapper.Map<CustomerResponseModel>(customer);
            // var response = new CustomerResponseModel()
            // {
            //     Id = customer.CustomerId,
            //     Name = customer.Name,
            //     Phone = customer.Phone
            // };
            return Ok(customerResult);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
    
    [HttpGet("city")]
    public async Task<IActionResult> GetCustomerByCity(string city)
    {
        try
        {
            var customers = await _customerRepository.GetCustomerByCityAsync(city);
            var customerResult = _mapper.Map<IEnumerable<CustomerResponseModel>>(customers);

            return Ok(customerResult);
        }
        catch (Exception ex)
        { 
            return BadRequest(ex.Message);
        }
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