using LivingLab.Web.UIServices.Accessory;
using LivingLab.Web.UIServices.Account;
using LivingLab.Web.UIServices.Device;
using LivingLab.Web.UIServices.Equipment;
using LivingLab.Web.UIServices.Identity;
using LivingLab.Web.UIServices.LabAccess;
using LivingLab.Web.UIServices.LabBooking;
using LivingLab.Web.UIServices.LabProfile;
using LivingLab.Web.UIServices.ManualLogs;
using LivingLab.Web.UIServices.NotificationManagement;
using LivingLab.Web.UIServices.SessionStats;

namespace LivingLab.Web.Configuration;

/// <summary>
/// Team P1-3 & P1-5 to add dependency injections for mod 1 here.
/// </summary>
public static class ConfigureManagementServices
{
    public static IServiceCollection AddManagementServices(this IServiceCollection services)
    {
        AddWebTransientServices(services);
        AddWebScopedServices(services);
        AddWebSingletonServices(services);
        return services;
    }

    private static IServiceCollection AddWebTransientServices(this IServiceCollection services)
    {
        services.AddTransient<IDeviceService, DeviceService>();
        services.AddTransient<IAccessoryService, AccessoryService>();
        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<INotificationManagementService, NotificationManagementService>();
        services.AddTransient<ILabBookingService, LabBookingService>();
        services.AddTransient<ILabProfileService, LabProfileService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<ILabAccessService, LabAccessService>();
        services.AddTransient<ISessionStatsService, SessionStatsService>();
        services.AddTransient<IEquipmentService, EquipmentService>();

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
