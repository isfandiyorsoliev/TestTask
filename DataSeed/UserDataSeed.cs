using ProductTask.Entities.UserEntities;
using ProductTask.Helpers;
using ProductTask.Services.Interface;

namespace ProductTask.DataSeed;

public static class UserDataSeed
{
    public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
    {
        var userService = serviceProvider.GetRequiredService<IUserService>();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        
        // Check if admin user already exists
        var existingAdmin = await userService.GetUserByEmailAsync(configuration["Admin:Email"]!);
        if (existingAdmin != null) return;
        
        var user = new User
        {
            FirstName = configuration["Admin:FirstName"]!,
            LastName = configuration["Admin:LastName"]!,
            Email = configuration["Admin:Email"]!,
            Password = configuration["Admin:Password"]!,
            PhoneNumber = configuration["Admin:PhoneNumber"]!,
            Role = configuration["Admin:Role"]!
        };

        await userService.CreateUserAsync(user);
    }
}