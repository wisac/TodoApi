using TodoApi.Dtos.Todos;
using TodoApi.Models;

namespace TodoApi.Repositories;

public interface ITodoRepo
{
   Task CreateTodoAsync(TodoCreateDto todo);
   Task<IEnumerable<Todo>> GetAllTodosAsync();
   Task<Todo> GetTodoByIdAsync(int id);
   void DeleteTodo(int id);
   Task<Todo> UpdateTodoAsync(TodoUpdateDto todo);
   Task SaveChangesAsync();
}
