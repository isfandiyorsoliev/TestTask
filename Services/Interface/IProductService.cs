using ProductTask.Entities.ProductEntities;
using ProductTask.Models;

namespace ProductTask.Services.Interface;

public interface IProductService
{
    Task<Product?> GetProductByIdAsync(int id);
    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
    Task<PaginatedResponse<Product>> GetProductsAsync(PagingModel paging);
}