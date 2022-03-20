namespace LivingLab.Core.Entities.Prediction;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class PredictionModelInput
{
    public string DeviceType { get; set; }
    
    public string DeviceSerialNo { get; set; }

    public float EnergyUsage { get; set; }

    public float Interval { get; set; }

    public string LoggedAt { get; set; }
}
