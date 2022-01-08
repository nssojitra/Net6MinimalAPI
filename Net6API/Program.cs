

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ToDoDb>(options => options.UseInMemoryDatabase("items"));

var app = builder.Build();



app.Run();

