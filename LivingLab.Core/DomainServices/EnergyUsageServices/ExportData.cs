using System.Text;

using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
using LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
namespace LivingLab.Core.DomainServices.EnergyUsageServices;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class ExportData : IExportData
{
    public byte[] ExportContentBuilder (List<DeviceEnergyUsageDTO> Content)
    {
        var builder = new StringBuilder();
        var ColNames = "";
        foreach(var propertyInfo in typeof(DeviceEnergyUsageDTO).GetProperties())
        {
            ColNames = ColNames + propertyInfo.Name + ",";
        }
        builder.AppendLine(ColNames);
        foreach (var item in Content)
        {
            builder.AppendLine($"{item.DeviceSerialNo},{item.DeviceType},{item.TotalEnergyUsage},{item.EnergyUsagePerHour},{item.EnergyUsageCost}");
        }
        return Encoding.UTF8.GetBytes(builder.ToString());
    }
}