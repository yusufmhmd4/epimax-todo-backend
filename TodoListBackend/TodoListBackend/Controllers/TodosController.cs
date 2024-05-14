using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListBackend.Entities;
using TodoListBackend.Models;

namespace TodoListBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoDbContext _todoDbContext;

        public TodosController(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }

        [HttpGet]  // Getting All Todos
        public async Task<IActionResult> GetAllTodos()
        {
            var todos = await _todoDbContext.Todos.ToListAsync();
            return Ok(todos);
        }

        [HttpPost]  // Creating New Todo
        public async Task<IActionResult> CreateTodo(Todo todo)
        {
            if ( todo == null)
            {
                return BadRequest("All Fields Required");
            };
            
            _todoDbContext.Todos.Add(todo);
            await _todoDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{Id}")]  // Getting Specific Todo
        public async Task<IActionResult> GetTodo(int Id)
        {
            var todo = await _todoDbContext.Todos.FindAsync(Id);

            if (todo == null)
            {
                return BadRequest("Invalid Todo Id");
            }
            return Ok(todo);

        }

        [HttpDelete("{Id}")]  // Deleting Specific Todo
        public async Task<IActionResult> DeleteTodo(int Id)
        {
            var todo = await _todoDbContext.Todos.FindAsync(Id);

            if(todo == null)
            {
                return NotFound();
            }

            _todoDbContext.Todos.Remove(todo);

            await _todoDbContext.SaveChangesAsync();

            return NoContent();

        }

        [HttpPatch("{Id}")] //Updating Todo Status
        public async Task<IActionResult> UpdateTodoStatus(int Id)
        {
            var todo = await _todoDbContext.Todos.FindAsync(Id);

            if( todo == null)
            {
                return BadRequest("Todo Not Found");
            }

            todo.Status = !todo.Status;
            await _todoDbContext.SaveChangesAsync();

            return NoContent();

        }

        [HttpPatch("description/{Id}")] // Updating todo Description
        public async Task<IActionResult> UpdateTodoDescription(int Id, [FromBody] string newDescription)
        {
            var todo = await _todoDbContext.Todos.FindAsync(Id);
            if (todo == null)
            {
                return BadRequest("Todo Not Found");
            }

            todo.Description = newDescription;
            await _todoDbContext.SaveChangesAsync();

            return NoContent();
        }


    }
}
