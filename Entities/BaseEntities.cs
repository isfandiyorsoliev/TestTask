using ProductTask.Common.Interfaces;

namespace ProductTask.Entities;


public class BaseEntity : IWithId, IWithCreatedAt
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class BaseEntityWithName : IWithId, IWithName, IWithCreatedAt
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class BaseEntityWithDeleted : IWithId, IWithCreatedAt, IWithDeleted
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}
