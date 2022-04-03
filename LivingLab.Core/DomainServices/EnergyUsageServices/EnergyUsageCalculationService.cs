
using LivingLab.Core.Entities;
using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
namespace LivingLab.Core.DomainServices.EnergyUsageServices;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class EnergyUsageCalculationService : IEnergyUsageCalculationService 
{
    public int CalculateEnergyUsageInWatt(int totalEU, int totalEUTime)
    {
        double EU = totalEU / (totalEUTime*60);
        return (int) EU;
    }

    public int CalculateEnergyUsagePerHour(double totalEU, int totalEUTime) 
    {
        double hour = (double)totalEUTime / (double)60;
        double EUPerHour = totalEU / hour;
        return (int)EUPerHour;
    }
    public double CalculateEnergyUsageCost(double cost, double totalEU) 
    {
        double total = Math.Round((cost * (double)totalEU /1000),2);
        return total;
    }
    public double CalculateEnergyIntensity(int area, int totalEU) 
    {
        return Math.Round(((double)totalEU / (double)area),2);
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
