using LivingLab.Web.UIServices.Accessory;
using LivingLab.Web.UIServices.Device;
using LivingLab.Web.UIServices.LabProfile;
using LivingLab.Web.UIServices.ManualLogs;
using LivingLab.Web.UIServices.UserManagement;

namespace LivingLab.Web.Configuration;

/// <summary>
/// This is the BASE configuration class for dependency injection in the WEB PROJECT.
/// You should not need to touch this file.
///
/// Team P1-1 & P1-2: Inject into ConfigureEnergyMonitoringServices.cs
/// Team P1-3 & P1-5: Inject into ConfigureManagementServices.cs
/// </summary>
///
/// <remarks>
/// Author: Team P1-1
/// </remarks>
public static class ConfigureWebServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddEnergyMonitoringServices();
        services.AddManagementServices();
        services.AddTransient<IManualLogService, ManualLogService>();
        services.AddTransient<IDeviceService, DeviceService>();
        services.AddTransient<IAccessoryService, AccessoryService>();
        services.AddTransient<IUserManagementService, UserManagementService>();
        services.AddTransient<ILabProfileService, LabProfileService>();

        return services;
    }

    private static IServiceCollection AddWebScopedServices(this IServiceCollection services)
    {
        return services;
    }
    private static IServiceCollection AddWebSingletonServices(this IServiceCollection services)
    {
        return services;
    }
}
