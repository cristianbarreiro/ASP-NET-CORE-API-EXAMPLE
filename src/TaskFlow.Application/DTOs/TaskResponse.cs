namespace TaskFlow.Application.DTOs;

public sealed record TaskResponse(
    Guid Id,
    string Title,
    string? Description,
    bool IsCompleted,
    DateTime CreatedAtUtc,
    DateTime? UpdatedAtUtc);
