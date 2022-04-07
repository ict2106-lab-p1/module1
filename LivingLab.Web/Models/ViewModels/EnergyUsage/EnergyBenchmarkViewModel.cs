using System.ComponentModel.DataAnnotations;

namespace LivingLab.Web.Models.ViewModels.EnergyUsage;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyBenchmarkViewModel
{
    public int LabId { get; set; }
    public string? LabLocation { get; set; }

    // no. of users in a lab
    public int Capacity { get; set; }
    public int NoOfDevices { get; set; }
    [Display(Name = "Energy Usage Benchmark (kWh/day)")]
    public double EnergyUsageBenchmark { get; set; }
}
