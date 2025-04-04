using Microsoft.AspNetCore.Mvc;
using ProductTask.Entities.UserEntities;
using ProductTask.Models;
using ProductTask.Services.Interface;

namespace ProductTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService, IAuthService authService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        try
        {
            var user = await userService.GetUserByIdAsync(id);
            return Ok(user);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("User not found.");
        }
    }

    [HttpGet("email/{email}")]
    public async Task<ActionResult<User>> GetUserByEmail(string email)
    {
        try
        {
            var user = await userService.GetUserByEmailAsync(email);
            return Ok(user);
        }
        catch (KeyNotFoundException)
        {
            return NotFound("User not found.");
        }
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<User>>> GetUsers([FromQuery] PagingModel paging)
    {
        var result = await userService.GetUsersAsync(paging);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        var created = await userService.CreateUserAsync(user);
        return CreatedAtAction(nameof(GetUserById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<User>> UpdateUser(int id, User user)
    {
        if (id != user.Id)
            return BadRequest("User ID mismatch.");

        var updated = await userService.UpdateUserAsync(user);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await userService.DeleteUserAsync(id);
        return NoContent();
    }
}
