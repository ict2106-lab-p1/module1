
using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
namespace LivingLab.Core.DomainServices.EnergyUsageServices;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class EnergyUsageCalculationService : IEnergyUsageCalculationService 
{
    public int CalculateEnergyUsagePerHour(double totalEU, int totalEUTime) 
    {
        double hour = (double)totalEUTime / (double)60;
        double EUPerHour = totalEU / hour;
        return (int)EUPerHour;
    }
    public double CalculateEnergyUsageCost(double cost, double totalEU, double totalEUTime) 
    {
        double total = Math.Round((cost * (double)totalEU * (double)(totalEUTime/60)),2);
        return total;
    }
    public double CalculateEnergyIntensity(int area, int totalEU) 
    {
        return (double)totalEU / (double)area;
    }
    public double CalculateDeviceEUInLab(List<EnergyUsageLog> logs) 
    {
        throw new NotImplementedException();
    }
    public int CalculateBenchMarkForLab(int totalEU, int labCount) 
    {
        throw new NotImplementedException();
    }
    public int CalculateBenchMarkForDeviceType(int totalEU, int deviceCount) 
    {
        throw new NotImplementedException();
    }
    public int CalculateCarbonFootPrint(int totalEU)
    {
        throw new NotImplementedException();
    }
}