using Microsoft.AspNetCore.Mvc;
using TodoApi.Dtos.Todos;
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
}
