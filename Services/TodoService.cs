using TodoApi.Data;
using TodoApi.Dtos.Todos;
using TodoApi.Models;

namespace TodoApi.Services;

public class TodoService : ITodoService
{
   private readonly ITodoRepo _repo;

   public TodoService(ITodoRepo repo, IUserService userRepo)
   {
      _repo = repo;
   }

   public async Task<TodoReadDto?> CreateTodo(TodoCreateDto todo)
   {
      var newTodo = await _repo.CreateTodoAsync(TodoMapper.MapToTodo(todo));
      if (newTodo == null)
      {
         return null;
      }
      await _repo.SaveChangesAsync();

      return TodoMapper.MapToDto(newTodo);
   }

   public async Task<bool> DeleteTodo(int id)
   {
      var todo = await _repo.GetTodoByIdAsync(id);
      if (todo == null)
      {
         return false;
      }
      _repo.DeleteTodo(todo);
      await _repo.SaveChangesAsync();
      return true;
   }

   public async Task<IEnumerable<TodoReadDto>> GetAllTodos()
   {
      var todos = await _repo.GetAllTodosAsync();

      // if(todos == null){
      //    return [];
      // }

      List<TodoReadDto> dtos = [];

      foreach (var todo in todos)
      {
         dtos.Add(TodoMapper.MapToDto(todo));
      }
      return dtos;
   }

   public async Task<TodoReadDto?> GetTodoById(int id)
   {
      var todo = await _repo.GetTodoByIdAsync(id);
      return todo == null ? null : TodoMapper.MapToDto(todo);
   }

   public async Task<IEnumerable<TodoReadDto>> SearchTodos(
      int? userId,
      Priority? priority,
      string? title,
      string? description
   )
   {
      var todos = await _repo.SearchTodosAsync(userId, priority, title,description);
      List<TodoReadDto> dtos = [];
      foreach (var todo in todos)
      {
         dtos.Add(TodoMapper.MapToDto(todo));
      }
      return dtos;
   }
}

public static class TodoMapper
{
   public static Todo MapToTodo(TodoCreateDto dto)
   {
      return new Todo()
      {
         Title = dto.Title,
         Description = dto.Description,
         CreatedDate = DateTime.UtcNow,
         Priority = dto.Priority,
         UserId = dto.UserId,
      };
   }

   public static TodoReadDto MapToDto(Todo todo)
   {
      return new TodoReadDto()
      {
         Id = todo.Id,
         UserId = todo.UserId,
         Title = todo.Title,
         Description = todo.Description,
         Priority = todo.Priority,
         CompletedDate = todo.CompletedDate,
         CreatedDate = todo.CreatedDate,
         LastModifiedDate = todo.LastModifiedDate,
      };
   }
}
