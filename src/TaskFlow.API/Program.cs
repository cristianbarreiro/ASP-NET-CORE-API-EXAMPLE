using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces;
using TaskFlow.Application.Services;
using TaskFlow.Infrastructure.Persistence;
using TaskFlow.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<TaskFlowDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Data Source=taskflow.db"));
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TaskFlowDbContext>();
    await db.Database.EnsureCreatedAsync();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

public partial class Program { }
