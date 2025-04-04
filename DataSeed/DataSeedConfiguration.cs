namespace ProductTask.DataSeed;

public static class DataSeedConfiguration
{
    public static async Task SeedDataAsync(IServiceProvider serviceProvider)
    {
        await UserDataSeed.SeedUsersAsync(serviceProvider);
        await ProductDataSeed.SeedProductsAsync(serviceProvider);
    }
}