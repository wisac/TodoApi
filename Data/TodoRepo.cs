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
      if (user == null)
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

   public async Task<IEnumerable<Todo>> SearchTodosAsync(
      int? userId,
      Priority? priority,
      string? title,
      string? description
   )
   {
      var query = _context.Todos.AsQueryable();

      if (userId.HasValue)
      {
         query = query.Where(t => t.UserId == userId);
      }
      if (priority.HasValue)
      {
         query = query.Where(t => t.Priority == priority);
      }
      if (!string.IsNullOrEmpty(title))
      {
         query = query.Where(t => t.Title.Contains(title));
      }
      if (!string.IsNullOrEmpty(description))
      {
         query = query.Where(t => t.Description.Contains(description));
      }

      return await query.ToListAsync();
   }
}
