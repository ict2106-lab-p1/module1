using LivingLab.Web.UIServices.ManualLogs;
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
