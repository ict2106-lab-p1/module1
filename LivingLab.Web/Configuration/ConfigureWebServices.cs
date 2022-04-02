using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Entities.Secrets;
using LivingLab.Infrastructure.Data;
using LivingLab.Web.UIServices.EnergyUsage;
using LivingLab.Web.UIServices.ManualLogs;
using LivingLab.Web.UIServices.Accessory;
using LivingLab.Web.UIServices.Account;
using LivingLab.Web.UIServices.Device;
using LivingLab.Web.UIServices.LabProfile;
using LivingLab.Web.UIServices.SessionStats;
using LivingLab.Web.UIServices.LabAccess;
using LivingLab.Web.UIServices.LabBooking;
using LivingLab.Web.UIServices.LabProfile;
using LivingLab.Web.UIServices.NotificationManagement;
using LivingLab.Web.UIServices.Todo;
using LivingLab.Web.UIServices.UserManagement;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

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
        services.AddTransient<IManualLogService, ManualLogService>();
        // services.AddTransient<IExportToCSVService, ExportToCSVService>();
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
