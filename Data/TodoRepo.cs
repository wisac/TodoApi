using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data;

public class TodoRepo : ITodoRepo
{
   private readonly TodoDbContext _context;

   public TodoRepo(TodoDbContext dbContext)
   {
      _context = dbContext;
   }

   public async Task<Todo?> CreateTodoAsync(Todo todo)
   {
      // check if user id is valid and exist
      var user = _context.Users.FirstOrDefault(u => u.Id == todo.UserId);
      if(user == null)
      {
         return null;
      }
      await _context.Todos.AddAsync(todo);
      return todo;
   }

   public void DeleteTodo(Todo todo)
   {
      _context.Todos.Remove(todo);
   }

   public async Task<IEnumerable<Todo>> GetAllTodosAsync()
   {
      return await _context.Todos.ToListAsync();
   }

   public async Task<Todo?> GetTodoByIdAsync(int id)
   {
      return await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
   }

   public async Task SaveChangesAsync()
   {
      await _context.SaveChangesAsync();
   }

   public async Task UpdateTodoAsync(Todo todo)
   {
      var todoToUpdate = await _context.Todos.FirstOrDefaultAsync(t => t.Id == todo.Id);

      if (todoToUpdate == null)
      {
         return;
      }
      _context.Todos.Update(todo);
   }
}
