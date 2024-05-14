using Microsoft.EntityFrameworkCore;
using TodoListBackend.Models;

namespace TodoListBackend.Entities
{
    public class TodoDbContext : DbContext 
    {
        public TodoDbContext(DbContextOptions options) : base ( options) { } 

        public DbSet<Todo> Todos {  get; set; }
    }
}
