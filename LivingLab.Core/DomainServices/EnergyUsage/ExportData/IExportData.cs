using LivingLab.Core.Entities.DTO.EnergyUsage;

namespace LivingLab.Core.DomainServices.EnergyUsage.ExportData;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public interface IExportData
{
     public byte[] ExportContentBuilder(List<DeviceEnergyUsageDTO> Content);
}