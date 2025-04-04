using ProductTask.Models.Requests;
using ProductTask.Models.Responses;

namespace ProductTask.Services.Interface;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(string email, string password);
    Task<LoginResponse> RegisterAsync(RegisterRequest request);
}