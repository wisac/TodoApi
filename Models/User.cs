using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models;

public class User
{
   [Key]
   [Required]
   public int Id { get; set; }

   [Required]
   [MinLength(1)]
   [MaxLength(50)]
   public string FirstName { get; set; } = string.Empty;

   [Required]
   [MinLength(1)]
   [MaxLength(50)]
   public string LastName { get; set; } = string.Empty;

   [Key]
   [Required]
   [EmailAddress]
   public string Email { get; set; } = string.Empty;

   [Required]
   public string HashedPassword { get; set; } = string.Empty;

   public ICollection<Todo> Todos { get; set; }
}
