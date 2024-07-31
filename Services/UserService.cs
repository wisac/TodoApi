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

      return UserMapper.MapToDto(user);
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

      return user == null ? null : UserMapper.MapToDto(user);
   }

   public Task<UserReadDto?> UpdateUser(UserUpdateDto userDto)
   {
      throw new NotImplementedException();
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

   public static User MapToUser(UserUpdateDto userDto)
   {
      return new User()
      {
         Id = userDto.Id,
         FirstName = userDto.FirstName,
         LastName = userDto.LastName,
         Email = userDto.Email
      };
   }

   public static UserReadDto MapToDto(User user)
   {
      var dto = new UserReadDto();

      dto.Id = user.Id;
      dto.FirstName = user.FirstName;
      dto.LastName = user.LastName;
      dto.Email = user.Email;
      dto.TotalTodos = user.Todos.Count;
      dto.TotalCompleted = user.Todos.Count(t => t.CompletedDate != null);
   

      return dto;
   }
}
