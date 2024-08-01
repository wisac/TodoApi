using System.ComponentModel.DataAnnotations;

namespace TodoApi.Dtos.Todos;

public class TodoReadDto : TodoDto
{
   [Key]
   [Required]
   public int Id { get; set; }

   [Required]
   [DataType(DataType.DateTime)]
   public DateTime CreatedDate { get; set; }

   public DateTime? LastModifiedDate { get; set; }

   public DateTime? CompletedDate { get; set; }
}
