namespace LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageCalculation;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class EnergyUsageCalculationService : IEnergyUsageCalculationService
{
    /// <summary>
    /// Calculate the energy usage in watt
    /// </summary>
    /// <param name="totalEU">total EU used</param>
    /// <param name="totalEUTime">total usage time</param>
    /// <returns>energy usage in watt</returns>
    public int CalculateEnergyUsageInWatt(int totalEU, int totalEUTime)
    {
        double EU = totalEU / (totalEUTime * 60);
        return (int)EU;
    }

    /// <summary>
    /// Calculate the energy usage cost
    /// </summary>
    /// <param name="cost">cost of ernergy per kWh</param>
    /// <param name="totalEUT">total EU used</param>
    /// <returns>energy usage in watt</returns>
    public double CalculateEnergyUsageCost(double cost, double totalEU)
    {
        double total = Math.Round((cost * (double)totalEU / 1000), 2);
        return total;
    }

    /// <summary>
    /// Calculate the energy usage intensity
    /// </summary>
    /// <param name="area">area of the lab</param>
    /// <param name="totalEUTime">end date</param>
    /// <returns>energy usage per sqaure meter</returns>
    public double CalculateEnergyIntensity(int area, int totalEU)
    {
        return Math.Round(((double)totalEU / (double)area), 2);
    }
}
