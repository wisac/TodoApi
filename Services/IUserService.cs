using TodoApi.Dtos.Users;
using TodoApi.Models;

namespace TodoApi.Services;

/// <summary>
/// An interface for the User service
/// </summary>
public interface IUserService
{
   
   Task<UserReadDto> CreateUser(UserCreateDto userDto);

   Task<UserReadDto?> GetUserById(int id);

   Task<List<UserReadDto>> GetAllUsers();

   Task<UserReadDto?> UpdateUser(UserUpdateDto userDto);

   Task DeleteUser(User user);
}
