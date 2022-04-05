using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.EnergyUsage;

namespace LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageTemplate;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class LabEnergyUsageConstructor: ConstructEnergyUsageTemplates<string>
{
    private List<LabEnergyUsageDTO> LabEUList = new List<LabEnergyUsageDTO>();
    private List<int> LabArea = new List<int>();
    public override List<string> GetIdentifier(List<EnergyUsageLog> logs)
    {
        var uniqueLab = new List<string>();
        foreach (var item in logs)
        {
            if (!uniqueLab.Contains(item.Lab.LabLocation))
            {
                uniqueLab.Add(item.Lab.LabLocation);
                LabArea.Add(item.Lab.Area??0);
            }
        }
        return uniqueLab;
    }

    public List<LabEnergyUsageDTO> MergeIntoCollection(List<EnergyUsageLog> logs)
    {
        var identifier = this.GetIdentifier(logs);
        // Console.WriteLine("id ="+identifier[0]);
        var totalEU = this.GetTotalEU(logs,identifier);
        // Console.WriteLine("EU ="+totalEU[0]);
        var intensity = this.GetIntensity(totalEU,LabArea);
        // Console.WriteLine("inte ="+intensity[0]);
        var cost = this.GetEUCost(totalEU);
        // Console.WriteLine("cost ="+cost[0]);
        var labDTO = new List<LabEnergyUsageDTO>();
        for (int i = 0; i < identifier.Count; i++)
        {
            labDTO.Add(
                new LabEnergyUsageDTO{
                    LabLocation = identifier[i],
                    TotalEnergyUsage = Math.Round(totalEU[i]/1000,2),
                    EnergyUsageIntensity = Math.Round(intensity[i]/1000,2),
                    EnergyUsageCost = cost[i]
                }
            );
        }
        return labDTO;

    }

    public List<double> GetTotalEU(List<EnergyUsageLog> logs, List<string> identifierList)
    {
        return base.BasicGetTotalEU(logs,identifierList);
    }

    public List<double> GetEUCost(List<double> energyList)
    {
        return BasicGetEUCost(energyList);
    }

    public List<double> GetIntensity(List<double> totalEU, List<int> area)
    {
        return BasicGetIntensity(totalEU, area);
    }
}
