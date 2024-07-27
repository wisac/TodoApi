using TodoApi.Data;
using TodoApi.Dtos.Todos;
using TodoApi.Models;

namespace TodoApi.Repositories;

public class TodoRepo : ITodoRepo
{
   private readonly TodoDbContext _context;

   public TodoRepo(TodoDbContext dbContext)
   {
      _context = dbContext;
   }

   public Task CreateTodoAsync(TodoCreateDto todo)
   {
      throw new NotImplementedException();
   }

   public void DeleteTodo(int id)
   {
      throw new NotImplementedException();
   }

   public Task<IEnumerable<Todo>> GetAllTodosAsync()
   {
      throw new NotImplementedException();
   }

   public Task<Todo> GetTodoByIdAsync(int id)
   {
      throw new NotImplementedException();
   }

   public Task SaveChangesAsync()
   {
      throw new NotImplementedException();
   }

   public Task<Todo> UpdateTodoAsync(TodoUpdateDto todo)
   {
      throw new NotImplementedException();
   }
}
