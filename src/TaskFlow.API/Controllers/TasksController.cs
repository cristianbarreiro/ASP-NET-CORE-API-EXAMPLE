using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Services;

namespace TaskFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class TasksController(TaskService service) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<TaskResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<TaskResponse>>> GetAll(CancellationToken ct) =>
        Ok(await service.GetAllAsync(ct));

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TaskResponse>> GetById(Guid id, CancellationToken ct)
    {
        var task = await service.GetByIdAsync(id, ct);
        return task is null ? NotFound() : Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<TaskResponse>> Create(
        [FromBody] CreateTaskRequest request, CancellationToken ct)
    {
        var created = await service.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id, [FromBody] UpdateTaskRequest request, CancellationToken ct)
    {
        var updated = await service.UpdateAsync(id, request, ct);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var deleted = await service.DeleteAsync(id, ct);
        return deleted ? NoContent() : NotFound();
    }
}
