namespace TodoApi.Dtos.Todos;

public class TodoUpdateDto : TodoDto
{
   public DateTime? LastModifiedDate { get; set; }
   public DateTime? CompletedDate { get; set; }
}
