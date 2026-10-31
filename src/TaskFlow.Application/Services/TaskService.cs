using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Services;

public sealed class TaskService(ITaskRepository repository)
{
    public async Task<IReadOnlyList<TaskResponse>> GetAllAsync(CancellationToken ct)
    {
        var tasks = await repository.GetAllAsync(ct);
        return tasks.Select(ToResponse).ToList();
    }

    public async Task<TaskResponse?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var task = await repository.GetByIdAsync(id, ct);
        return task is null ? null : ToResponse(task);
    }

    public async Task<TaskResponse> CreateAsync(CreateTaskRequest request, CancellationToken ct)
    {
        var task = new TaskItem(request.Title, request.Description);
        await repository.AddAsync(task, ct);
        await repository.SaveChangesAsync(ct);
        return ToResponse(task);
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateTaskRequest request, CancellationToken ct)
    {
        var task = await repository.GetByIdAsync(id, ct);
        if (task is null) return false;

        task.Update(request.Title, request.Description, request.IsCompleted);
        await repository.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
    {
        var task = await repository.GetByIdAsync(id, ct);
        if (task is null) return false;

        await repository.DeleteAsync(task, ct);
        await repository.SaveChangesAsync(ct);
        return true;
    }

    private static TaskResponse ToResponse(TaskItem task) =>
        new(task.Id, task.Title, task.Description, task.IsCompleted,
            task.CreatedAtUtc, task.UpdatedAtUtc);
}
