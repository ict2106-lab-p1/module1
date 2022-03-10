using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;
/// <summary>
/// This is an example of a domain entity class.
/// You can add data annotations to the properties if needed.
/// </summary>
public class Todo : BaseEntity
{
    // To mark a property as nullable, add the '?' after the type.
    public string? Title { get; set; }
    // To mark a property as required you can use the [Required] attribute.
    // There are other annotations that you can use such as [ColumnName] and [MaxLength] if you can to 
    // customize the database column.
    [Required]
    public string Description { get; set; }
    [Required]
    public string OTP { get; set; }
}
