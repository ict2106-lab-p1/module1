using LivingLab.Core.DomainServices;
using LivingLab.Core.DomainServices.EnergyUsageLogServices;
using LivingLab.Core.DomainServices.EnergyUsageServices;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Core.Interfaces.Services.CsvParser;
using LivingLab.Core.Interfaces.Services.EnergyUsageInterfaces;
using LivingLab.Infrastructure.InfraServices.CsvParser;
using LivingLab.Infrastructure.Repositories;

using Microsoft.Extensions.DependencyInjection;

namespace LivingLab.Infrastructure.Configuration;

/// <summary>
/// Team P1-1 & P1-2 to add dependency injections for mod 2 here.
/// </summary>
public static class ConfigureEnergyMonitoringServices
{
    public static IServiceCollection AddEnergyMonitoringServices(this IServiceCollection services)
    {
        AddTransientServices(services);
        AddScopedServices(services);
        AddSingletonServices(services);
        return services;
    }

    private static IServiceCollection AddTransientServices(this IServiceCollection services)
    {
        // Repositories
        services.AddTransient<IEnergyUsageRepository, EnergyUsageRepository>();
        services.AddTransient<ISmsRepository, SmsRepository>();
        services.AddTransient<IEmailRepository, EmailRepository>();
        services.AddTransient<IPowerGenerationMixRepository, PowerGenerationMixRepository>();

        // Services
        services.AddTransient<IEnergyUsageLogCsvParser, EnergyUsageLogCsvParser>();
        services.AddTransient<IManualLogDomainService, ManualLogDomainService>();
        services.AddTransient<INotificationDomainService, NotificationDomainService>();
        services.AddTransient<IEnergyLogDomainService, EnergyLogDomainService>();
        services.AddTransient<IEnergyUsageAnalysisService, EnergyUsageAnalysisService>();
        services.AddTransient<IEnergyUsageBuilder, DeviceEnergyUsageBuilder>();
        services.AddTransient<IEnergyUsageComparisonService, EnergyUsageComparisonService>();
        services.AddTransient<IEnergyUsageDomainService, EnergyUsageDomainService>();
        
        return services;
    }

    private static IServiceCollection AddScopedServices(this IServiceCollection services)
    {
        // services.AddScoped<ITodoRepository, TodoRepository>();

        return services;
    }
    
    private static IServiceCollection AddSingletonServices(this IServiceCollection services)
    {
        // services.AddSingleton<ITodoRepository, TodoRepository>();

        return services;
    }
}
