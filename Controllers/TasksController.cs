using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIProject.Models;
using System.ComponentModel.DataAnnotations;

namespace APIProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<TasksController> _logger;

    public TasksController(ApplicationDbContext context, ILogger<TasksController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET: api/Tasks
    [HttpGet]
    public async System.Threading.Tasks.Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
    {
        try
        {
            var tasks = await _context.Tasks.ToListAsync();
            return Ok(tasks);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting tasks");
            return StatusCode(500, "Internal server error");
        }
    }

    // GET: api/Tasks/5
    [HttpGet("{id}")]
    public async System.Threading.Tasks.Task<ActionResult<TaskItem>> GetTask(int id)
    {
        try
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound($"Task with id {id} not found");
            }

            return Ok(task);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting task {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }

    // POST: api/Tasks
    [HttpPost]
    public async System.Threading.Tasks.Task<ActionResult<TaskItem>> CreateTask([FromBody] CreateTaskDto taskDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = new TaskItem
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                IsCompleted = taskDto.IsCompleted ?? false,
                CreatedAt = DateTime.UtcNow
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating task");
            return StatusCode(500, "Internal server error");
        }
    }

    // PUT: api/Tasks/5
    [HttpPut("{id}")]
    public async System.Threading.Tasks.Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskDto taskDto)
    {
        try
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound($"Task with id {id} not found");
            }

            task.Title = taskDto.Title ?? task.Title;
            task.Description = taskDto.Description ?? task.Description;
            if (taskDto.IsCompleted.HasValue)
            {
                task.IsCompleted = taskDto.IsCompleted.Value;
            }
            task.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating task {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }

    // DELETE: api/Tasks/5
    [HttpDelete("{id}")]
    public async System.Threading.Tasks.Task<IActionResult> DeleteTask(int id)
    {
        try
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound($"Task with id {id} not found");
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting task {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }
}

// DTOs for request/response
public class CreateTaskDto
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    public bool? IsCompleted { get; set; }
}

public class UpdateTaskDto
{
    [MaxLength(200)]
    public string? Title { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    public bool? IsCompleted { get; set; }
}

