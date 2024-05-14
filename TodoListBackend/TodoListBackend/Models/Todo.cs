using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TodoListBackend.Models
{
    public class Todo
    {
        
        public int Id { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public bool Status { get; set; } = false; 
    }
}

