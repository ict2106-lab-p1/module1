using LivingLab.Core.Models;

namespace LivingLab.Web.UIServices.EnergyUsageAnalysisServices;

public interface IExportToCSVService
{
    public byte[] Export(List<DeviceEnergyUsageModel> Content);
}
