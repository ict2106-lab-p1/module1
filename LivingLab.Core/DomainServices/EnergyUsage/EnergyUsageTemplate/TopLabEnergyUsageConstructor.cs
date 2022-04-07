using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.EnergyUsage;

namespace LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageTemplate;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class TopLabEnergyUsageConstructor : ConstructEnergyUsageTemplates<string>
{
    private List<LabEnergyUsageDTO> LabEUList = new List<LabEnergyUsageDTO>();
    private List<int> LabArea = new List<int>();

    /// <summary>
    /// Get the top 5 index/identifer 
    /// </summary>
    /// <param name="logs">Energy usage log</param>
    /// <returns>list of labs</returns>
    public override List<string> GetIdentifier(List<EnergyUsageLog> logs)
    {
        var uniqueLab = new List<string>();
        var count = 0;
        foreach (var item in logs)
        {
            if (!uniqueLab.Contains(item.Lab.LabLocation) && count < 6)
            {
                uniqueLab.Add(item.Lab.LabLocation);
                LabArea.Add(item.Lab.Area ?? 0);
                count++;
            }
        }
        return uniqueLab;
    }

    /// <summary>
    /// merge all the string to form a collection of LabEnergyUsageDTO
    /// </summary>
    /// <param name="logs">Energy usage log</param>
    /// <returns>list of LabEnergyUsageDTO</returns>
    public List<LabEnergyUsageDTO> MergeIntoCollection(List<EnergyUsageLog> logs)
    {
        var identifier = this.GetIdentifier(logs);
        // Console.WriteLine("id ="+identifier[0]);
        var totalEU = this.GetTotalEU(logs, identifier);
        // Console.WriteLine("EU ="+totalEU[0]);
        var intensity = this.GetIntensity(totalEU, LabArea);
        // Console.WriteLine("inte ="+intensity[0]);
        var cost = this.GetEUCost(totalEU);
        // Console.WriteLine("cost ="+cost[0]);
        var labDTO = new List<LabEnergyUsageDTO>();
        for (int i = 0; i < identifier.Count; i++)
        {
            labDTO.Add(
                new LabEnergyUsageDTO
                {
                    LabLocation = identifier[i],
                    TotalEnergyUsage = Math.Round(totalEU[i] / 1000, 2),
                    EnergyUsageIntensity = Math.Round(intensity[i] / 1000, 2),
                    EnergyUsageCost = cost[i]
                }
            );
        }
        return labDTO;

    }

    /// <summary>
    /// Get the overall energy usage of each index
    /// </summary>
    /// <param name="logs">Energy usage log</param>
    /// <param name="identifierList"> list of index</param>
    /// <returns>list of EU</returns>
    public List<double> GetTotalEU(List<EnergyUsageLog> logs, List<string> identifierList)
    {
        return base.BasicGetTotalEU(logs, identifierList);
    }

    /// <summary>
    /// Get the overall energy usage cost of each index
    /// </summary>
    /// <param name="energyList">Energy usage log</param>
    /// <returns>list of EU cost</returns>
    public List<double> GetEUCost(List<double> energyList)
    {
        return BasicGetEUCost(energyList);
    }

    /// <summary>
    /// Get the overall energy usage intensity of each index
    /// </summary>
    /// <param name="totalEU">total energy usage</param>
    /// <param name="area">area of the lab</param>
    /// <returns>list of EU intensity</returns>
    public List<double> GetIntensity(List<double> totalEU, List<int> area)
    {
        return BasicGetIntensity(totalEU, area);
    }
}
