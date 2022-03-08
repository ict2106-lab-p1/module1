using System.ComponentModel.DataAnnotations;

namespace LivingLab.Core.Entities;

public class SessionStats : BaseEntity
{
    [Required] [DataType(DataType.Date)] public DateTime? Date { get; set; }
    [Required] [DataType(DataType.Date)] public DateTime? LoginTime { get; set; }
    [Required] [DataType(DataType.Date)] public DateTime? LogoutTime { get; set; }
    public double? DataUploaded { get; set; }
    public Lab Lab { get; set; }
}
