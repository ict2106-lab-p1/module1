namespace LivingLab.Core.Entities.DTO.Lab;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class LabDetailsDTO
{
    public int LabId { get; set; }
    public string? LabLocation { get; set; }
    public int Capacity { get; set; }
    public int NoOfDevices { get; set; }
    public double EnergyUsageBenchmark { get; set; }
}
