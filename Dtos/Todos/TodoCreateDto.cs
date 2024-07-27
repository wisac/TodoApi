using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Todo.Models;

namespace Todo.Dtos.Todos;

public class TodoCreateDto
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


   [Required]
   [DataType(DataType.DateTime)]
   public DateTime DateAdded { get; set; }


}
