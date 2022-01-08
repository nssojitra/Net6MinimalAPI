
namespace Net6MinimalAPI
{
    public class ToDo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }

    public class ToDoDb: DbContext
    {
        public ToDoDb(DbContextOptions options) : base(options) { }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
