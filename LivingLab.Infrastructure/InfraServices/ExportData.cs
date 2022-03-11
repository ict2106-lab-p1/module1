using System.Text;

using LivingLab.Core.Interfaces.Services;
using LivingLab.Core.Models;

namespace LivingLab.Infrastructure.InfraServices;

public class ExportData : IExportData
{
    public byte[] ExportContentBuilder (List<DeviceEnergyUsageModel> Content)
    {
        var builder = new StringBuilder();
        var ColNames = "";
        foreach(var propertyInfo in typeof(DeviceEnergyUsageModel).GetProperties())
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