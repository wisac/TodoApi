using System.ComponentModel.DataAnnotations;


namespace TodoApi.Dtos.Todos;

public class TodoCreateDto
{
   [Required]
   [DataType(DataType.DateTime)]
   public DateTime CreatedDate { get; set; }
}
