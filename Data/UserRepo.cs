using Microsoft.EntityFrameworkCore;
using TodoApi.Common;
using TodoApi.Models;

namespace TodoApi.Data;

public class UserRepo : IUserRepo
{
   private readonly TodoDbContext _context;

   public UserRepo(TodoDbContext dbContext)
   {
      _context = dbContext;
   }

   public async Task<User> CreateUserAsync(User user)
   {
      await _context.AddAsync(user);
      await _context.SaveChangesAsync();
      return user;
   }  

   public void DeleteUser(User user)
   {
      _context.Remove(user);
   }

   public async Task<IEnumerable<User>> GetAllUsersAsync()
   {
      var query = _context.Users.Include(u => u.Todos);
      return await query.ToListAsync();
   }

   public Task<User?> GetUserByAnyFieldAsync(FieldType fieldType, string value)
   {
      var user = fieldType switch
      {
         FieldType.Id => _context.Users.Include(u => u.Todos).FirstOrDefaultAsync(u => u.Id == int.Parse(value)),

         FieldType.Email => _context.Users.Include(u => u.Todos).FirstOrDefaultAsync(u => u.Email == value),

         _ => throw new NotImplementedException()
      };

      return user;
   }

   // public Task<User?> GetUserByEmailAsync(string email)
   // {
   //    var user = _context.Users.Include(u => u.Todos).FirstOrDefaultAsync(u => u.Email == email);

   //    return user;
   // }

   public async Task<User?> GetUserByIdAsync(int id)
   {
      var user = await _context.Users.Include(u => u.Todos).FirstOrDefaultAsync(u => u.Id == id);

      return user;
   }

   public async Task SaveChangesAsync()
   {
      await _context.SaveChangesAsync();
   }

   public async Task<User?> UpdateUserAsync(User user)
   {
      var userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
      if (userToUpdate == null)
      {
         return null;
      }

      _context.Entry(userToUpdate).CurrentValues.SetValues(user);

      return userToUpdate;
   }
}
