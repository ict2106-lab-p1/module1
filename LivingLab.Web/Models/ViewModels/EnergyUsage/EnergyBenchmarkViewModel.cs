using System.ComponentModel.DataAnnotations;

using LivingLab.Web.Models.ViewModels.Device;

namespace LivingLab.Web.Models.ViewModels.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyBenchmarkViewModel
{
    public int LabId { get; set; }
    public string LabLocation { get; set; }
    public int Capacity { get; set; }

    [Display(Name = "Energy Usage Benchmark (watts/day)")]
    public double EnergyUsageBenchmark { get; set; }
}
