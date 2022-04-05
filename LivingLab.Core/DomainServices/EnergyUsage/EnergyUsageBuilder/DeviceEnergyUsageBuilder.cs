using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageAnalysis;
using LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageCalculation;
using LivingLab.Core.Entities;
using LivingLab.Core.Entities.DTO.EnergyUsage;

namespace LivingLab.Core.DomainServices.EnergyUsage.EnergyUsageBuilder;
/// <remarks>
/// Author: Team P1-2
/// </remarks>

public class DeviceEnergyUsageBuilder: IEnergyUsageBuilder
{
    private readonly IEnumerable<EnergyUsageLog> _logs;
    private readonly IEnergyUsageCalculationService _calculator = new EnergyUsageCalculationService();
    private List<string> _unqiueList = new List<string>();
    private List<int> _eUList = new List<int>();
    private List<string> _deviceType = new List<string>();
    private List<EUWatt> _totalEU = new List<EUWatt>();
    private List<double> _totalCost = new List<double>();
    private double _cost = 0.2544;

    private DeviceEU _deviceEUList = new DeviceEU();
    public DeviceEnergyUsageBuilder(IEnumerable<EnergyUsageLog> logs) {
         _logs = logs;
         this.Reset();
    }

    public void BuildDistinctIdentifier ()
    {
        foreach (var item in _logs)
        {
            if (!this._unqiueList.Contains(item.Device.SerialNo))
            {
                this._unqiueList.Add(item.Device.SerialNo);
                this._eUList.Add(0);
                this._deviceType.Add(item.Device.Name);
            }

        }
    }
    public void BuildEUInWatt()
    {
        foreach (var item in _logs)
        {
            _totalEU.Add(new EUWatt
            {
                id = item.Device.SerialNo,
                EU = _calculator.CalculateEnergyUsageInWatt((int) item.EnergyUsage,item.Interval.Minutes)
            });
        }

        for (int i = 0; i < this._unqiueList.Count; i++)
        {
            for (int j = 0; j < this._totalEU.Count; j++)
            {
                if (this._totalEU[j].id == this._unqiueList[i])
                {
                    this._eUList[i] += this._totalEU[j].EU;
                }
            }
        }
    }
    public void BuildEUCost ()
    {
        for (int i = 0; i < this._unqiueList.Count; i++)
        {
             this._totalCost.Add(_calculator.CalculateEnergyUsageCost(this._cost,this._eUList[i]));
        }
    }
    public void BuildEUList()
    {
        for (int i = 0; i < this._unqiueList.Count; i++)
        {
            this._deviceEUList.Add(new DeviceEnergyUsageDTO{
                DeviceSerialNo =  this._unqiueList[i],
                DeviceType = this._deviceType[i],
                TotalEnergyUsage = this._eUList[i],
                EnergyUsageCost = this._totalCost[i]
                });
        }
    }

    public void Reset()
    {
        this._deviceEUList = new DeviceEU();
    }

    public List<DeviceEnergyUsageDTO> GetProduct()
    {
        DeviceEU result = this._deviceEUList;

        this.Reset();

        return result.product();
    }

}