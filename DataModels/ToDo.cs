using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels
{
    public class ToDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }

    public class ToDoDb : DbContext
    {
        public ToDoDb(DbContextOptions options) : base(options) { }
        public DbSet<ToDo> ToDos { get; set; }
    }
}