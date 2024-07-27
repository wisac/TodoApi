using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos.Users;

public class UserReadDto : UserDto
{
   public int TotalTodos { get; set; }

   public int TotalCompleted { get; set; }

   public int TotalPending => TotalTodos - TotalCompleted;
}
