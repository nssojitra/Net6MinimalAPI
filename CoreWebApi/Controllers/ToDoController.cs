using DataModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoDb _db;
        public ToDoController(ToDoDb db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _db.ToDos.ToListAsync());
        }

        [HttpGet("complete")]
        public async Task<IActionResult> GetCompleted()
        {
            return Ok(await _db.ToDos.Where(x => x.IsComplete).ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var obj = await _db.ToDos.FindAsync(id);
            if (obj == null) return NotFound();
            return Ok(obj);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDo(ToDo todo)
        {
            await _db.ToDos.AddAsync(todo);
            await _db.SaveChangesAsync();
            return Ok(todo);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateToDo(int id, ToDo todo)
        {
            var dbTodo = await _db.ToDos.FindAsync(id);
            if (dbTodo == null) return NotFound();

            dbTodo.Name = todo.Name;
            dbTodo.IsComplete = todo.IsComplete;

            await _db.SaveChangesAsync();
            return Ok(dbTodo);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            var dbTodo = await _db.ToDos.FindAsync(id);
            if (dbTodo == null) return NotFound();

            _db.ToDos.Remove(dbTodo);

            await _db.SaveChangesAsync();
            return Ok();
        }


    }
}
