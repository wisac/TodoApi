using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data;

public class TodoDbContext : DbContext
{
   public TodoDbContext(DbContextOptions<TodoDbContext> options)
      : base(options) { }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      modelBuilder
         .Entity<Todo>()
         .HasOne(t => t.User)
         .WithMany(u => u.Todos)
         .HasForeignKey(t => t.UserId);

      modelBuilder
         .Entity<Todo>()
         .Property(t => t.Priority)
         .HasConversion(v => v.ToString(), v => (Priority)Enum.Parse(typeof(Priority), v));
   }

   public DbSet<Todo> Todos { get; set; }
   public DbSet<User> Users { get; set; }
}
