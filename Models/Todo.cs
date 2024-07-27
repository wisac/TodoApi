using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Models;

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

   [NotMapped]
   public bool Completed => DateCompleted.HasValue;

   [Required]
   [DataType(DataType.DateTime)]
   public DateTime DateAdded { get; set; }

   public DateTime? DateCompleted { get; set; }

    // navigation property
   public User User { get; set; }
}
