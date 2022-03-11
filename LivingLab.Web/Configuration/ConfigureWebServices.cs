<<<<<<< HEAD
using LivingLab.Web.UIServices.EnergyUsageAnalysisServices;
using LivingLab.Web.UIServices.ManualLogs;
=======
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
using LivingLab.Web.UIServices.Accessory;
using LivingLab.Web.UIServices.Device;
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
<<<<<<< HEAD

    private static IServiceCollection AddWebTransientServices(this IServiceCollection services)
    {
        services.AddTransient<ITodoService, TodoService>();
        services.AddTransient<IManualLogService, ManualLogService>();
        services.AddTransient<IExportToCSVService, ExportToCSVService>();
        services.AddTransient<IDeviceService, DeviceService>();
        services.AddTransient<IAccessoryService, AccessoryServices>();

        return services;
    }

=======
    
    private static IServiceCollection AddWebTransientServices(this IServiceCollection services)
    {
        services.AddTransient<ITodoService, TodoService>();
        services.AddTransient<IDeviceService, DeviceService>();
        services.AddTransient<IAccessoryService, AccessoryServices>();
        
        return services;
    }
    
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
    private static IServiceCollection AddWebScopedServices(this IServiceCollection services)
    {
        return services;
    }
<<<<<<< HEAD
=======
    
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
    private static IServiceCollection AddWebSingletonServices(this IServiceCollection services)
    {
        return services;
    }
}
