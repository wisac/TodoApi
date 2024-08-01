using TodoApi.Dtos.Todos;
using TodoApi.Models;

namespace TodoApi.Services;

public interface ITodoService
{
   public Task<TodoReadDto?> CreateTodo(TodoCreateDto todo);

   public Task<TodoReadDto?> GetTodoById(int id);

   public Task<IEnumerable<TodoReadDto>> GetAllTodos();

   public Task<bool> DeleteTodo(int id);

   public Task<IEnumerable<TodoReadDto>> SearchTodos(
      int? userId,
      Priority? priority,
      string? title,
      string? description
   );
}
