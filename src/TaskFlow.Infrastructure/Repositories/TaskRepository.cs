using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Persistence;

namespace TaskFlow.Infrastructure.Repositories;

public sealed class TaskRepository(TaskFlowDbContext db) : ITaskRepository
{
    public async Task<IReadOnlyList<TaskItem>> GetAllAsync(CancellationToken ct) =>
        await db.Tasks.AsNoTracking().OrderByDescending(x => x.CreatedAtUtc).ToListAsync(ct);

    public Task<TaskItem?> GetByIdAsync(Guid id, CancellationToken ct) =>
        db.Tasks.FirstOrDefaultAsync(x => x.Id == id, ct);

    public async Task AddAsync(TaskItem task, CancellationToken ct) =>
        await db.Tasks.AddAsync(task, ct);

    public Task SaveChangesAsync(CancellationToken ct) => db.SaveChangesAsync(ct);

    public Task DeleteAsync(TaskItem task, CancellationToken ct)
    {
        db.Tasks.Remove(task);
        return Task.CompletedTask;
    }
}
