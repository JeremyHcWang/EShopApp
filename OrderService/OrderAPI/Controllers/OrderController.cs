using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderAPI_ApplicationCore.Contracts.RepositoryInterfaces;
using OrderAPI_ApplicationCore.Entities;
using OrderAPI_ApplicationCore.Models.Response;

namespace OrderAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly IOrderRepositoryAsync _orderRepository;
    private readonly IMapper _mapper;
    
    public OrderController(IHttpClientFactory httpClientFactory, IOrderRepositoryAsync orderRepository, IMapper mapper)
    {
        //use IHttpClientFactory to avoid potential issues with socket exhaustion and DNS changes
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress= new Uri("http://customerapi");
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
   
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _orderRepository.GetAllAsync());
    }
    
    [HttpGet("byCustomer/")]
    public async Task<IActionResult> GetFromCustomerServiceAsync(int customerId)
    {
        HttpResponseMessage result = await _httpClient.GetAsync($"/api/customer/{customerId}");
        if (result.IsSuccessStatusCode)
        {
            var customerResult = await result.Content.ReadFromJsonAsync<OrderCustomerDto>();
               
            return Ok(customerResult);
        }
        return StatusCode((int)result.StatusCode, result.ReasonPhrase);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddOrder(Order obj)
    {
        try
        {   
            obj.OrderDate = DateTime.UtcNow;
            var result = await _orderRepository.InsertAsync(obj);
            return Ok(result);
        }
        catch (Exception ex)
        { 
            return BadRequest(ex.Message);
        }
    }
}