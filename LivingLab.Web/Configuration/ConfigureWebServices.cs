using LivingLab.Web.UIServices.EnergyUsage;
using LivingLab.Web.UIServices.ManualLogs;
using LivingLab.Web.UIServices.Accessory;
using LivingLab.Web.UIServices.Account;
using LivingLab.Web.UIServices.Device;
using LivingLab.Web.UIServices.SessionStats;
using LivingLab.Web.UIServices.Identity;
using LivingLab.Web.UIServices.LabAccess;
using LivingLab.Web.UIServices.LabBooking;
using LivingLab.Web.UIServices.LabProfile;
using LivingLab.Web.UIServices.NotificationManagement;
using LivingLab.Web.UIServices.Todo;

namespace LivingLab.Web.Configuration;

/// <summary>
/// This is the BASE configuration class for dependency injection in the WEB PROJECT.
/// You should not need to touch this file.
///
/// Team P1-1 & P1-2: Inject into ConfigureEnergyMonitoringServices.cs
/// Team P1-3 & P1-5: Inject into ConfigureManagementServices.cs
/// </summary>
public static class ConfigureWebServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddEnergyMonitoringServices();
        services.AddManagementServices();
        services.AddTransient<ITodoService, TodoService>();
        return services;
    }
}
