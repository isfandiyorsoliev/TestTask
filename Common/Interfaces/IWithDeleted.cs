namespace ProductTask.Common.Interfaces;

public interface IWithDeleted
{
    bool IsDeleted { get; set; }
    DateTime? DeletedAt { get; set; }
}

