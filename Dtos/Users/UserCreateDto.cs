using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Todo.Dtos.Users;

public class UserCreateDto : UserBasicDto
{
   [Required]
   [MinLength(6)]
   [PasswordPropertyText]
   public string Password { get; set; }
}
