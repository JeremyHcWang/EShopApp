using Microsoft.AspNetCore.Mvc;
using ProductAPI_ApplicationCore.Contracts.RepositoryInterfaces;
using ProductAPI_ApplicationCore.Entities;

namespace ProductAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepositoryAsync _productRepository;

    public ProductController(IProductRepositoryAsync productRepository)
    {
        _productRepository = productRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _productRepository.GetAllAsync());
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Product product)
    {
        if (product == null) return BadRequest("Product cannot be null");

        try
        {
            var result = await _productRepository.InsertAsync(product);
            if (result > 0)
            {
                return NoContent(); // Indicates successful update without sending data back
            }
            return BadRequest("Unable to update the product.");
        }
        catch (Exception ex)
        { 
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _productRepository.DeleteAsync(id);
        if (result == 0) return NotFound($"Product with ID {id} not found.");

        return NoContent(); // Indicates successful deletion without sending data back
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return NotFound($"Product with ID {id} not found.");

        return Ok(product);
    }
}