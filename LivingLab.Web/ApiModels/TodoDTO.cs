
using Microsoft.Build.Framework;

namespace LivingLab.Web.ApiModels;

public class TodoDTO
{
    public int Id { get; set; }
    public string OTP { get; set; }

    public class CreateTodoDTO
    {
        [Required]
        public string OTP { get; set; }
    }
}
