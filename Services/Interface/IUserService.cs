using ProductTask.Entities.UserEntities;
using ProductTask.Models;

namespace ProductTask.Services.Interface;

public interface IUserService
{
    Task<User> GetUserByIdAsync(int id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<User> CreateUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
    Task<PaginatedResponse<User>> GetUsersAsync(PagingModel paging); 
}