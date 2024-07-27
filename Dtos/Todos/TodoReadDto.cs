using System.ComponentModel.DataAnnotations;
namespace TodoApi.Dtos.Todos;


public class TodoReadDto : TodoDto
{
   [Required]
   [DataType(DataType.DateTime)]
   public DateTime CreatedDate { get; set; }

   public DateTime? LastModifiedDate { get; set; }

   public DateTime? CompletedDate { get; set; }
}
