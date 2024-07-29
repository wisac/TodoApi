using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos.Users;

public class UserCreateDto : UserDto
{
   [Required]
   [MinLength(6)]
   [PasswordPropertyText]
   public string Password { get; set; } = string.Empty;

   
}
