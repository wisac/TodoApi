using TodoApi.Models;
using TodoApi.Common;

namespace TodoApi.Data;

/// <summary>
/// Interface for the User Repository
/// </summary>
public interface IUserRepo
{
   
   /// <summary> Create a new User </summary>
   /// <param name="user">The User to create </param>
   /// <returns>A Task </returns>
   Task<User> CreateUserAsync(User user);

   /// <summary> Get all Users </summary>
   /// <returns>A Task of IEnumerable of Users </returns>
   Task<IEnumerable<User>> GetAllUsersAsync();

   /// <summary> Get a User by Id </summary>
   /// <param name="id">The Id of the User </param>
   /// <returns>A Task of User </returns>
   Task<User?> GetUserByIdAsync(int id);


   // /// <summary> Get a User by Email </summary>
   // /// <param name="email">The Email of the User </param>
   // /// <returns>A Task of User </returns>
   // Task<User?> GetUserByEmailAsync(string email);

   /// <summary> Delete a User </summary>
   /// <param name="user">The User to delete </param>
   void DeleteUser(User user);

   /// <summary> Update a User </summary>
   /// <param name="user">The User to update </param>
   /// <returns>A Task of User </returns>
   Task SaveChangesAsync();

   /// <summary> Get a User by any search type and field </summary>
   /// <param name="fieldType">The type of search to perform </param>
   /// <param name="value">The value to search for </param>
   /// <returns>A Task of User </returns>
   Task<User?> GetUserByAnyFieldAsync(FieldType fieldType, string value);
}



