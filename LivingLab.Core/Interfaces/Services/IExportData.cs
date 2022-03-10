using LivingLab.Core.Models;
namespace LivingLab.Core.Interfaces.Services;

public interface IExportData
{
     public byte[] ExportContentBuilder(List<DeviceEnergyUsageModel> Content);
}