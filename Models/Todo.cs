using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models;

public class Todo
{
   [Required]
   [Key]
   public int Id { get; set; }

   [Required]
   [ForeignKey("User")]
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
   public DateTime CreatedDate { get; set; }

   public DateTime? LastModifiedDate { get; set; }

   public DateTime? CompletedDate { get; set; }

   // navigation property
   public User User { get; set; }
}
