using Microsoft.EntityFrameworkCore;
using ProductTask.Entities.UserEntities;
using ProductTask.Helpers;
using ProductTask.Models;
using ProductTask.Services.Interface;

namespace ProductTask.Services.Implementation;

public class UserService(AppDbContext context) : IUserService
{
    public async Task<User> GetUserByIdAsync(int id)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted)
               ?? throw new KeyNotFoundException("User not found.");
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
    }

    public async Task<User> CreateUserAsync(User user)
    {
        user.Password = HashHelpers.HashPassword(user.Password);
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        var existingUser = await GetUserByIdAsync(user.Id);
        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;
        existingUser.PhoneNumber = user.PhoneNumber;
        existingUser.Role = user.Role;

        context.Users.Update(existingUser);
        await context.SaveChangesAsync();
        return existingUser;
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await GetUserByIdAsync(id);
        user.IsDeleted = true;
        context.Users.Update(user);
        await context.SaveChangesAsync();
    }

    public async Task<PaginatedResponse<User>> GetUsersAsync(PagingModel paging)
    {
        var query = context.Users
            .Where(u => !u.IsDeleted)
            .AsNoTracking();

        var totalItems = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItems / (double)paging.PageSize);

        var users = await query
            .Skip((paging.PageNumber - 1) * paging.PageSize)
            .Take(paging.PageSize)
            .ToListAsync();

        paging.TotalItems = totalItems;
        paging.TotalPages = totalPages;

        return new PaginatedResponse<User>
        {
            Items = users,
            Paging = paging
        };
    }
}