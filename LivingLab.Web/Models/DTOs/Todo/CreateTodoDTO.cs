using Microsoft.Build.Framework;

namespace LivingLab.Web.Models.DTOs.Todo;

public class CreateTodoDTO
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
}
