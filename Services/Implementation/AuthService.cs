using ProductTask.Constants;
using ProductTask.Entities.UserEntities;
using ProductTask.Helpers;
using ProductTask.Models.Requests;
using ProductTask.Models.Responses;
using ProductTask.Services.Interface;

namespace ProductTask.Services.Implementation;

public class AuthService(IUserService userService, IConfiguration configuration) : IAuthService
{
    public async Task<LoginResponse> LoginAsync(string email, string password)
    {
        var user = await userService.GetUserByEmailAsync(email);

        if (!HashHelpers.VerifyPassword(password, user!.Password))
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Invalid email or password."
            };
        }

        return new LoginResponse
        {
            Success = true,
            Message = "Login successful",
            Token = HashHelpers.GenerateToken(user.Id, configuration)
        };
    }

    public async Task<LoginResponse> RegisterAsync(RegisterRequest request)
    {
        var existingUser = await userService.GetUserByEmailAsync(request.Email);
        if (existingUser != null)
        {
            return new LoginResponse
            {
                Success = false,
                Message = "User with this email already exists."
            };
        }

        var userRequest = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Role = RoleConstants.Admin,
            Password = HashHelpers.HashPassword(request.Password),
            PhoneNumber = request.PhoneNumber
        };
        
        var user = await userService.CreateUserAsync(userRequest);
        return new LoginResponse
        {
            Success = true,
            Message = "Registration successful",
            Token = HashHelpers.GenerateToken(user.Id, configuration)
        };
    }
}