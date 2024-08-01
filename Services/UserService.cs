using Microsoft.Extensions.Logging;
using TodoApi.Data;
using TodoApi.Dtos.Users;
using TodoApi.Models;

namespace TodoApi.Services;

public class UserService : IUserService
{
   private readonly IUserRepo _repo;
   private readonly ILogger<UserService> _logger;

   public UserService(IUserRepo repo, ILogger<UserService> logger)
   {
      _repo = repo;
      _logger = logger;
   }

   public async Task<UserReadDto> CreateUser(UserCreateDto userDto)
   {
      // has password
      var hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(userDto.Password, 13);
      // update password with hash
      userDto.Password = hashedPassword;
      // save to db
      var user = await _repo.CreateUserAsync(UserMapper.MapToUser(userDto));
      await _repo.SaveChangesAsync();
      
      return UserMapper.MapToDto(user);

   }

   public Task DeleteUser(User user)
   {
      throw new NotImplementedException();
   }

   public async Task<List<UserReadDto>> GetAllUsers()
   {
      var users = await _repo.GetAllUsersAsync();
      List<UserReadDto> dtos = [];
      foreach (var user in users)
      {
         dtos.Add(UserMapper.MapToDto(user));
      }
      return dtos;
   }

   public async Task<UserReadDto?> GetUserById(int id)
   {
      var user = await _repo.GetUserByIdAsync(id);
      return user == null ? null : UserMapper.MapToDto(user);
   }

   public async Task<UserReadDto?> UpdateUser(UserUpdateDto userDto, int id)
   {
      var user = await _repo.GetUserByIdAsync(id);
      if (user == null)
      {
         return null;
      }

      // update entity
      UserMapper.MapToUser(userDto, user);
      // save changes
      await _repo.SaveChangesAsync();

      return UserMapper.MapToDto(user);
   }
}

public static class UserMapper
{
   public static User MapToUser(UserCreateDto userDto)
   {
      return new User()
      {
         FirstName = userDto.FirstName,
         LastName = userDto.LastName,
         Email = userDto.Email,
         HashedPassword = userDto.Password
      };
   }

   public static User MapToUser(UserUpdateDto userDto, User user)
   {
      user.FirstName = userDto.FirstName;
      user.LastName = userDto.LastName;
      user.Email = userDto.Email;
      return user;
   }

   public static UserReadDto MapToDto(User user)
   {
      var dto = new UserReadDto
      {
         Id = user.Id,
         FirstName = user.FirstName,
         LastName = user.LastName,
         Email = user.Email,
         TotalTodos = user.Todos.Count,
         TotalCompleted = user.Todos.Count(t => t.CompletedDate != null)
      };

      return dto;
   }
}
