
using Microsoft.Build.Framework;

namespace LivingLab.Web.ApiModels;

public class TodoDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public class CreateTodoDTO
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
