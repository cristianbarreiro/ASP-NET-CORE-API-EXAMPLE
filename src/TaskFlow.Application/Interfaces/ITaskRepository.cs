using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces;

public interface ITaskRepository
{
    Task<IReadOnlyList<TaskItem>> GetAllAsync(CancellationToken cancellationToken);
    Task<TaskItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(TaskItem task, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    Task DeleteAsync(TaskItem task, CancellationToken cancellationToken);
}
