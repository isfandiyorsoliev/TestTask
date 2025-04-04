using ProductTask.Entities;

namespace ProductTask.Entities.UserEntities;

public class User: BaseEntityWithDeleted
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public string Role { get; set; } = "";
}