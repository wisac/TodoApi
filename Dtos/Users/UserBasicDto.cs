using System.ComponentModel.DataAnnotations;

namespace Todo.Dtos.Users;

public class UserBasicDto
{
   [Required]
   [MinLength(1)]
   [MaxLength(50)]
   public string FirstName { get; set; } = string.Empty;

   [Required]
   [MinLength(1)]
   [MaxLength(50)]
   public string LastName { get; set; } = string.Empty;

   [Required]
   [EmailAddress]
   public string Email { get; set; } = string.Empty;
}
