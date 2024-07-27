using TodoApi.Data;
using TodoApi.Dtos.Users;
using TodoApi.Models;

namespace TodoApi.Repositories;

public class UserRepo : IUserRepo
{
   private readonly TodoDbContext _context;

   public UserRepo(TodoDbContext dbContext)
   {
      _context = dbContext;
   }

   public Task CreateUserAsync(UserCreateDto user)
   {
      throw new NotImplementedException();
   }

   public void DeleteUser(int id)
   {
      throw new NotImplementedException();
   }

   public Task<IEnumerable<User>> GetAllUsersAsync()
   {
      throw new NotImplementedException();
   }

   public Task<User> GetUserByIdAsync(int id)
   {
      throw new NotImplementedException();
   }

   public Task SaveChangesAsync()
   {
      throw new NotImplementedException();
   }

   public Task<User> UpdateUserAsync(UserUpdateDto user)
   {
      throw new NotImplementedException();
   }
}
