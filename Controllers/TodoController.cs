using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using TodoApi.Dtos.Todos;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/todos")]
public class TodoController : ControllerBase
{
   private readonly ITodoService _service;

   public TodoController(ITodoService service)
   {
      _service = service;
   }

   [HttpPost]
   public async Task<IActionResult> CreateTodo(TodoCreateDto todo)
   {
      var newTodo = await _service.CreateTodo(todo);

      return newTodo == null ? NotFound() : Created($"api/todos/{newTodo.Id}", newTodo);
   }

   [HttpDelete("{id}")]
   public async Task<IActionResult> DeleteTodo(int id)
   {
      bool deleted = await _service.DeleteTodo(id);
      return deleted ? NoContent() : NotFound();
   }

   [HttpGet]
   public async Task<IActionResult> GetAllTodos()
   {
      var todos = await _service.GetAllTodos();
      return Ok(todos);
   }

   [HttpGet("{id}")]
   public async Task<IActionResult> GetTodoById(int id)
   {
      var todo = await _service.GetTodoById(id);
      return todo == null ? NotFound() : Ok(todo);
   }

   [HttpGet("search")]
   public async Task<IActionResult> SearchTodo(
      [FromQuery] int? userId,
      [FromQuery] Priority? priority,
      [FromQuery] string? title,
      [FromQuery] string? description
   )
   {
      var todos = await _service.SearchTodos(userId, priority, title,description);
      return Ok(todos);
   }
}
