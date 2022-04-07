using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageAnalysis;
using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageCalculation;
using LivingLab.Core.Entities;

namespace LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageTemplate;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public abstract class ConstructEnergyUsageTemplates<T>
{
    private readonly IEnergyUsageCalculationService _calculator = new EnergyUsageCalculationService();
    public abstract List<T> GetIdentifier(List<EnergyUsageLog> logs);

    /// <summary>
    /// Get the overall energy usage of each index
    /// </summary>
    /// <param name="logs">Energy usage log</param>
    /// <param name="identifierList"> list of index</param>
    /// <returns>list of EU</returns>
    public List<double> BasicGetTotalEU(List<EnergyUsageLog> logs, List<string> identifierList)
    {
        var TotalEU = new List<double>();
        for (int i = 0; i < identifierList.Count; i++)
        {
            TotalEU.Add(0);
        }
        var energyList = BasicGetEUWatt(logs);

        for (int i = 0; i < identifierList.Count; i++)
        {
            for (int j = 0; j < energyList.Count; j++)
            {
                if (energyList[j].id == identifierList[i])
                {
                    TotalEU[i] += energyList[j].EU;
                }
            }
        }
        return TotalEU;

    }

    /// <summary>
    /// Get the overall energy usage cost in watt of each log
    /// </summary>
    /// <param name="logs">Energy usage log</param>
    /// <returns>list of EU</returns>
    public List<EUWatt> BasicGetEUWatt(List<EnergyUsageLog> logs)
    {
        var energyList = new List<EUWatt>();
        foreach (var item in logs)
        {
            energyList.Add(new EUWatt
            {
                id = item.Lab.LabLocation,
                EU = _calculator.CalculateEnergyUsageInWatt((int)item.EnergyUsage, item.Interval.Minutes)
            });
        }
        return energyList;
    }

    /// <summary>
    /// Get the overall energy usage cost of each index
    /// </summary>
    /// <param name="energyList">Energy usage log</param>
    /// <returns>list of EU cost</returns>
    public List<double> BasicGetEUCost(List<double> energyList)
    {
        var TotalCost = new List<double>();
        double cost = 0.2544;

        for (int i = 0; i < energyList.Count; i++)
        {
            TotalCost.Add(_calculator.CalculateEnergyUsageCost(cost, energyList[i]));
        }
        return TotalCost;
    }

    /// <summary>
    /// Get the overall energy usage intensity of each index
    /// </summary>
    /// <param name="totalEU">total energy usage</param>
    /// <param name="area">area of the lab</param>
    /// <returns>list of EU intensity</returns>
    public List<double> BasicGetIntensity(List<double> totalEU, List<int> area)
    {
        var TotalIntensity = new List<double>();
        for (int i = 0; i < totalEU.Count; i++)
        {
            TotalIntensity.Add(_calculator.CalculateEnergyIntensity(area[i], (int)totalEU[i]));
        }
        return TotalIntensity;
    }

}
