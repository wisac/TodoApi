using TodoApi.Dtos.Users;
using TodoApi.Models;

namespace TodoApi.Services;

/// <summary>
/// An interface for the User service
/// </summary>
public interface IUserService
{
   
   /// <summary>
   /// Create a new User
   /// </summary>
   /// <param name="userDto"> The User to create
   /// </param>
   /// <returns>A Task of UserReadDto
   /// </returns>
   Task<UserReadDto> CreateUser(UserCreateDto userDto);


/// <summary>
/// Get a User by Id
/// </summary>
/// <param name="id">
/// The Id of the User
/// </param>
/// <returns>
/// A Task of UserReadDto
/// </returns>
   Task<UserReadDto?> GetUserById(int id);

   /// <summary>
   /// Get all Users
   /// </summary>
   /// <returns>
   /// A Task of List of UserReadDto
   /// </returns>
   Task<List<UserReadDto>> GetAllUsers();


   /// <summary>
   /// Update a User
   /// </summary>
   /// <param name="userDto">
   /// The User to update
   /// </param>
   /// <param name="id">
   /// The Id of the User
   /// </param>
   /// <returns>
   /// A Task of UserReadDto
   /// </returns>
   Task<UserReadDto?> UpdateUser(UserUpdateDto userDto, int id);

   /// <summary>
   /// Delete a User
   /// </summary>
   /// <param name="id">
   /// The Id of the User
   /// </param>
   /// <returns>
   /// A Task of true if successful or false if not
   /// </returns>
   Task<bool> DeleteUser(int id);
}
