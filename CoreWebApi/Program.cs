using DataModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ToDoDb>(options => options.UseInMemoryDatabase("todoItems"));

var app = builder.Build();


app.UseAuthorization();

app.MapControllers();

app.Run();
