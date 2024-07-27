using TodoApi.Dtos.Users;
using TodoApi.Models;

namespace TodoApi.Repositories;

public interface IUserRepo
{
   
   Task CreateUserAsync(UserCreateDto user);
   Task<IEnumerable<User>> GetAllUsersAsync();
   Task<User> GetUserByIdAsync(int id);
   void DeleteUser(int id);
   Task<User> UpdateUserAsync(UserUpdateDto user);
   Task SaveChangesAsync();
}
