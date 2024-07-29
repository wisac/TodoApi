using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos.Users;

public class UserReadDto : UserDto
{  
   [Required]
   public int Id { get; set; }

   public int TotalTodos { get; set; }

   public int TotalCompleted { get; set; }

   public int TotalPending => TotalTodos - TotalCompleted;

   
}
