using ProductTask.Services.Implementation;
using ProductTask.Services.Interface;

namespace ProductTask.Extensions;

public static class ServiceConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
    }
}