using ProductTask.Entities.ProductEntities;
using ProductTask.Models;
using ProductTask.Services.Interface;

namespace ProductTask.DataSeed;

public static class ProductDataSeed
{
    public static async Task SeedProductsAsync(IServiceProvider serviceProvider)
    {
        var productService = serviceProvider.GetRequiredService<IProductService>();
        
        var existingProducts = await productService.GetProductsAsync(new PagingModel());
        if (existingProducts.Items.Any()) return;

        var products = new List<Product>
        {
            new Product
            {
                Name = "Product 1",
                Description = "Description 1",
                Price = 10.99,
                Quantity = 100
            },
            new Product
            {
                Name = "Product 2",
                Description = "Description 2",
                Price = 20.99,
                Quantity = 200
            },
            new Product
            {
                Name = "Product 3",
                Description = "Description 3",
                Price = 30.99,
                Quantity = 30
            }
        };

        foreach (var product in products)
        {
            await productService.CreateProductAsync(product);
        }
    }
}