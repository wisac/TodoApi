using TodoApi.Models;

namespace TodoApi.Data;

/// <summary>
/// Interface for the Todo Repository
/// </summary>
public interface ITodoRepo
{
   /// <summary> Create a new Todo </summary>
   /// <param name="todo">The Todo to create </param>
   /// <returns>A Task </returns>
   Task CreateTodoAsync(Todo todo);

   /// <summary> Get all Todos </summary>
   /// <returns>A Task of IEnumerable of Todos </returns>
   Task<IEnumerable<Todo>> GetAllTodosAsync();

   /// <summary> Get a Todo by Id </summary>
   /// <param name="id">The Id of the Todo </param>
   /// <returns>A Task of Todo </returns>
   Task<Todo?> GetTodoByIdAsync(int id);

   /// <summary> Delete a Todo </summary>
   /// <param name="todo">The Todo to delete </param>
   void DeleteTodo(Todo todo);

   /// <summary> Update a Todo </summary>
   /// <param name="todo">The Todo to update </param>
   /// <returns>A Task of Todo </returns>
   Task UpdateTodoAsync(Todo todo);

   /// <summary> Save changes to the database </summary>
   /// <returns>A Task </returns>
   Task SaveChangesAsync();
}
