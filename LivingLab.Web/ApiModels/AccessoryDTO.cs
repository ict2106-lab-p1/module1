
namespace LivingLab.Domain.Entities;
using Microsoft.Build.Framework;


public class AccessoryDTO
{
    public string? status { get; set; }

    public DateTime ValidityDate { get; set; }

    public Lab? Lab { get; set; }
    public AccessoryType? AccessoryType { get; set; }
}