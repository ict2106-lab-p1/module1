using LivingLab.Web.UIServices.EnergyUsageAnalysisServices;
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
/// This is the configuration class for dependency injection in the WEB PROJECT.
/// Add any new classes that need to be injected here.
/// </summary>
public static class ConfigureWebServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        AddWebTransientServices(services);
        AddWebScopedServices(services);
        AddWebSingletonServices(services);
        return services;
    }

    private static IServiceCollection AddWebTransientServices(this IServiceCollection services)
    {
        services.AddTransient<ITodoService, TodoService>();
        services.AddTransient<IManualLogService, ManualLogService>();
        services.AddTransient<IExportToCSVService, ExportToCSVService>();
        services.AddTransient<IDeviceService, DeviceService>();
        services.AddTransient<IAccessoryService, AccessoryServices>();
        services.AddTransient<ISessionStatsService, SessionStatsService>();
        // Add application services.
        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<INotificationManagementService, NotificationManagementService>();
        services.AddTransient<ILabBookingService, LabBookingService>();
        services.AddTransient<ILabProfileService, LabProfileService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<ILabAccessService, LabAccessService>();

        return services;
    }

    private static IServiceCollection AddWebScopedServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
        return services;
    }
    private static IServiceCollection AddWebSingletonServices(this IServiceCollection services)
    {
        services.AddTransient<IAccountService, AccountService>();
        return services;
    }
}
