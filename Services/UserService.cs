using TodoApi.Dtos.Users;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Services;

public class UserService : IUserService
{
   private readonly UserRepo _repo;

   public UserService(UserRepo repo)
   {
      _repo = repo;
   }

   public async Task CreateUser(UserCreateDto userDto)
   {
      // has password
      var hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(userDto.Password, 13);

      // update password with hash
      userDto.Password = hashedPassword;

      // save to db
      await _repo.CreateUserAsync(MapToUser(userDto));
   }

   public Task DeleteUser(User user)
   {
      throw new NotImplementedException();
   }

   public Task<List<UserReadDto>> GetAllUsers()
   {
      throw new NotImplementedException();
   }

   public async Task<UserReadDto?> GetUserById(int id)
   {
     var user = await _repo.GetUserByIdAsync(id);

      return user == null ? null : MapToDto(user);
   }

   public Task<UserReadDto?> UpdateUser(UserUpdateDto userDto)
   {
      throw new NotImplementedException();
   }

   private static User MapToUser(UserCreateDto userDto)
   {
      return new User()
      {
         FirstName = userDto.FirstName,
         LastName = userDto.LastName,
         Email = userDto.Email,
         HashedPassword = userDto.Password
      };
   }

   private static User MapToUser(UserUpdateDto userDto) {
      return new User()
      {
         Id = userDto.Id,
         FirstName = userDto.FirstName,
         LastName = userDto.LastName,
         Email = userDto.Email
      };
   }

   private static UserReadDto MapToDto(User user) {
      return new UserReadDto()
      {
         Id = user.Id,
         FirstName = user.FirstName,
         LastName = user.LastName,
         Email = user.Email,
         TotalTodos = user.Todos.Count,
         TotalCompleted = user.Todos.Count(t => t.CompletedDate != null),
      };
   }
}
