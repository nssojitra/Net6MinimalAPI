
namespace Net6MinimalAPI
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/todos", async (ToDoDb db) => Results.Ok(await db.ToDos.ToListAsync()));

            app.MapGet("/todos/incomplete", async (ToDoDb db) => Results.Ok(await db.ToDos.Where(t => !t.IsComplete).ToListAsync()));

            app.MapGet("/todos/{id}", async (ToDoDb db, int id) => {

                var pizza = await db.ToDos.FindAsync(id);

                if (pizza is null) return Results.NotFound();
                return Results.Ok(pizza);
            });

            app.MapPost("/todos", async (ToDoDb db, ToDo p) =>
            {
                await db.ToDos.AddAsync(p);
                await db.SaveChangesAsync();
                return Results.Ok(p);
            });

            app.MapPut("/todos/{id}", async (ToDoDb db, ToDo p, int id) =>
            {
                var pizza = await db.ToDos.FindAsync(id);

                if (pizza is null) return Results.NotFound();

                pizza.Name = p.Name;
                pizza.IsComplete = p.IsComplete;

                await db.SaveChangesAsync();

                return Results.Ok(p);
            });

            app.MapDelete("/todos/{id}", async (ToDoDb db, int id) =>
            {
                var pizza = await db.ToDos.FindAsync(id);

                if (pizza is null) return Results.NotFound();

                db.ToDos.Remove(pizza);
                await db.SaveChangesAsync();

                return Results.NoContent();
            });
        }
    }
}
