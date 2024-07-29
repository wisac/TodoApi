using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos.Users;

public class UserUpdateDto : UserDto
{
   [Required]
   public int Id { get; set; }
}
