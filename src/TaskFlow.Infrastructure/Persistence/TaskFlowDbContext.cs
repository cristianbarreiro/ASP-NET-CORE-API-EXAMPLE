using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Persistence;

public sealed class TaskFlowDbContext(DbContextOptions<TaskFlowDbContext> options) : DbContext(options)
{
    public DbSet<TaskItem> Tasks => Set<TaskItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Title).HasMaxLength(120).IsRequired();
            entity.Property(x => x.Description).HasMaxLength(1000);
        });
    }
}
