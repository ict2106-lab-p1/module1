using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
using LivingLab.Web.UIServices.EnergyUsage;
using LivingLab.Web.UIServices.ManualLogs;

using IEnergyUsageComparisonService = LivingLab.Web.UIServices.EnergyUsage.IEnergyUsageComparisonService;
using IManualLogService = LivingLab.Web.UIServices.ManualLogs.IManualLogService;

namespace LivingLab.Web.Configuration;

/// <summary>
/// Team P1-1 & P1-2 to add dependency injections for mod 2 here.
/// </summary>
public static class ConfigureEnergyMonitoringServices
{
    public static IServiceCollection AddEnergyMonitoringServices(this IServiceCollection services)
    {
        AddWebTransientServices(services);
        AddWebScopedServices(services);
        AddWebSingletonServices(services);
        return services;
    }

    private static IServiceCollection AddWebTransientServices(this IServiceCollection services)
    {
        services.AddTransient<IManualLogService, ManualLogService>();
        services.AddTransient<IEnergyUsageAnalysisUIService, EnergyUsageAnalysisUIService>();
        services.AddTransient<IEnergyUsageComparisonService, EnergyUsageComparisonService>();
        services.AddTransient<IEnergyUsageService, EnergyUsageService>();

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
