using Microsoft.AspNetCore.Mvc;
using ProductTask.Entities.ProductEntities;
using ProductTask.Models;
using ProductTask.Services.Interface;

namespace ProductTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService): ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        try
        {
            var product = await productService.GetProductByIdAsync(id);
            return Ok(product);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Product not found.");
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        var created = await productService.CreateProductAsync(product);
        return CreatedAtAction(nameof(GetProductById), new { id = created.Id }, created);
    }

    [HttpPut]
    public async Task<ActionResult<Product>> UpdateProduct(Product product)
    {
        var updated = await productService.UpdateProductAsync(product);
        return Ok(updated);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await productService.DeleteProductAsync(id);
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<Product>>> GetProducts([FromQuery] PagingModel paging)
    {
        var result = await productService.GetProductsAsync(paging);
        return Ok(result);
    }
}