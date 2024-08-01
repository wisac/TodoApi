using TodoApi.Dtos.Todos;

namespace TodoApi.Services;

public interface ITodoService
{
   public Task<TodoReadDto?> CreateTodo(TodoCreateDto todo);

   public Task<TodoReadDto?> GetTodoById(TodoReadDto todo);

   public Task<IEnumerable<TodoReadDto>> GetAllTodos();

   public Task<bool> DeleteTodo(int id);
}
