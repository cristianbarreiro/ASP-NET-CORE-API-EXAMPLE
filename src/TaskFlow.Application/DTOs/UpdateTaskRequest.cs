using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Application.DTOs;

public sealed class UpdateTaskRequest
{
    [Required, StringLength(120, MinimumLength = 3)]
    public string Title { get; init; } = string.Empty;

    [StringLength(1000)]
    public string? Description { get; init; }
    public bool IsCompleted { get; init; }
}
