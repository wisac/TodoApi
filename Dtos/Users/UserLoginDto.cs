using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos.Users;

public class UserLoginDto
{
   [Required]
   [EmailAddress]
   public string Email { get; set; } = string.Empty;

   [Required]
   [MinLength(6)]
   [PasswordPropertyText]
   public string Password { get; set; } = string.Empty;
}
