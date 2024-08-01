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

   public Task<IEnumerable<TodoReadDto>> GetAllTodos()
   {
      throw new NotImplementedException();
   }

   public Task<TodoReadDto> GetTodoById(TodoReadDto todo)
   {
      throw new NotImplementedException();
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
