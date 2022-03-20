namespace LivingLab.Core.Entities.DTO.EnergyUsageDTOs;
/// <remarks>
/// Author: Team P1-2
/// </remarks>
public class DeviceInLabDTO 
{
    public string? LabLocation { get; set; }

    public string? DeviceType { get; set;}

    public int TotalEnergyUsage { get; set;}
}