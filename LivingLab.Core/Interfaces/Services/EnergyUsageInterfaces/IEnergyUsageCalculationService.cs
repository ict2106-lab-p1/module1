using LivingLab.Core.Entities;
namespace LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public interface IEnergyUsageCalculationService 
{
    public int CalculateEnergyUsageInWatt(int totalEU, int totalEUTime);
    public int CalculateEnergyUsagePerHour(double totalEU, int totalEUTime);
    public double CalculateEnergyUsageCost(double cost, double totalEU);
    public double CalculateEnergyIntensity(int area, int totalEU);
    public double CalculateDeviceEUInLab(List<EnergyUsageLog> logs);
    public int CalculateBenchMarkForLab(int totalEU, int labCount);
    public int CalculateBenchMarkForDeviceType(int totalEU, int deviceCount);
    public int CalculateCarbonFootPrint(int totalEU);
}