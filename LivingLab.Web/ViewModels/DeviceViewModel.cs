namespace LivingLab.Web.ViewModels;
<<<<<<< HEAD

public class DeviceViewModel
{
    public Lab Lab { get; set; }
    public List<Device> Devices { get; set; }
=======
    
using LivingLab.Domain.Entities;
public class DeviceViewModel
{
    public int Id { get; set; }
    public DateTime ValidityDate { get; set; }

    public string? serialNo { get; set; }
    public Lab Lab { get; set; }
    public DeviceType DeviceType { get; set; }
>>>>>>> 7177fb045fda2cf42579f6e724d0b614b71063e4
}
