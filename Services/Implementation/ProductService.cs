using Microsoft.EntityFrameworkCore;
using ProductTask.Entities.ProductEntities;
using ProductTask.Models;
using ProductTask.Services.Interface;

namespace ProductTask.Services.Implementation;

public class ProductService(AppDbContext context): IProductService
{
    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        var existingProduct = await GetProductByIdAsync(product.Id);
        existingProduct!.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.Price = product.Price;
        existingProduct.Quantity = product.Quantity;
        
        context.Products.Update(existingProduct);
        await context.SaveChangesAsync();
        return existingProduct;
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await GetProductByIdAsync(id);
        product!.IsDeleted = true;
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task<PaginatedResponse<Product>> GetProductsAsync(PagingModel paging)
    {
        var query = context.Products.Where(p => !p.IsDeleted);
        
        var totalItems = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItems / (double)paging.PageSize);
        
        var products = await query
            .Skip((paging.PageNumber - 1) * paging.PageSize)
            .Take(paging.PageSize)
            .ToListAsync();
        
        paging.TotalItems = totalItems;
        paging.TotalPages = totalPages;

        return new PaginatedResponse<Product>
        {
            Paging = paging,
            Items = products
        };
    }
}