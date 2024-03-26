using Microsoft.AspNetCore.Mvc;
using OrderAPI_ApplicationCore.Models.Response;

namespace OrderAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly HttpClient _httpClient;
    public OrderController(IHttpClientFactory httpClientFactory)
    {
        //use IHttpClientFactory to avoid potential issues with socket exhaustion and DNS changes
        _httpClient = httpClientFactory.CreateClient();
        //_httpClient.BaseAddress= new Uri("http://host.docker.internal:8002");
        _httpClient.BaseAddress= new Uri("http://customerapi");
        // For local testing
        //_httpClient.BaseAddress= new Uri("http://localhost:5179");
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetCustomerByIdFromCustomerServiceAsync(int customerId)
    {
        HttpResponseMessage result = await _httpClient.GetAsync($"/api/customer/{customerId}");
        if (result.IsSuccessStatusCode)
        {
            var customerResult = await result.Content.ReadFromJsonAsync<CustomerResponseModel>();
               
            return Ok(customerResult);
        }
        return StatusCode((int)result.StatusCode, result.ReasonPhrase);
    }
}