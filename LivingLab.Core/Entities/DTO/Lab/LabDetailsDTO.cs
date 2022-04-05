namespace LivingLab.Core.Entities.DTO.Lab;

public class LabDetailsDTO
{
    public int LabId { get; set; }
    public string LabLocation { get; set; }
    public int Capacity { get; set; }
    public int NoOfDevices { get; set; }
    public double EnergyUsageBenchmark { get; set; }
}
