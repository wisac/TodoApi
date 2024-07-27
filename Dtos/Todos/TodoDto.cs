using System.ComponentModel.DataAnnotations;
using TodoApi.Models;

namespace TodoApi.Dtos.Todos;

public class TodoDto
{
   [Required]
   public int UserId { get; set; }

   [Required]
   [EnumDataType(typeof(Priority))]
   public Priority Priority { get; set; } = Priority.Normal;

   [Required]
   [MinLength(1)]
   [MaxLength(100)]
   public string Title { get; set; } = string.Empty;

   [MaxLength(500)]
   public string Description { get; set; } = string.Empty;

   // navigation property
}
