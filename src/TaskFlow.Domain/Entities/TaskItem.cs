namespace TaskFlow.Domain.Entities;

public sealed class TaskItem
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public bool IsCompleted { get; private set; }
    public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAtUtc { get; private set; }

    private TaskItem() { } // For EF Core

    public TaskItem(string title, string? description)
    {
        Update(title, description, false);
    }

    public void Update(string title, string? description, bool isCompleted)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("The title is required.", nameof(title));

        Title = title.Trim();
        Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
        IsCompleted = isCompleted;
        UpdatedAtUtc = DateTime.UtcNow;
    }
}
