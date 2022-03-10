using LivingLab.Core.DomainServices;

using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Infrastructure.Data;
using LivingLab.Infrastructure.InfraServices;
using LivingLab.Infrastructure.InfraServices.CsvParser;
using LivingLab.Infrastructure.Repositories;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LivingLab.Infrastructure.Configuration;

public static class ConfigureServiceContainer
{
    public static void ConfigurePasswordPolicy(this IServiceCollection services) =>
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 0;
        });

    public static void AddIdentities(this IServiceCollection services) =>
        services.AddDefaultIdentity<ApplicationUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        AddTransientServices(services);
        AddScopedServices(services);
        AddSingletonServices(services);
        return services;
    }

    private static IServiceCollection AddTransientServices(this IServiceCollection services)
    {
        // Repositories
        services.AddTransient<ITodoRepository, TodoRepository>();
        services.AddTransient<IEnergyUsageRepository, EnergyUsageRepository>();
        services.AddTransient<ISmsRepository, SmsRepository>();
        services.AddTransient<IEmailRepository, EmailRepository>();
        services.AddTransient<IPowerGenerationMixRepository, PowerGenerationMixRepository>();
        
        // Services
        services.AddTransient<ITodoDomainService, TodoDomainService>();
        services.AddTransient<IEnergyUsageLogCsvParser, EnergyUsageLogCsvParser>();
        services.AddTransient<IExportData, ExportData>();
        services.AddTransient<IEnergyUsageService, EnergyUsageService>();
        services.AddTransient<IManualLogDomainService, ManualLogDomainService>();
        services.AddTransient<INotificationDomainService, NotificationDomainService>();
        services.AddTransient<IEnergyLogDomainService, EnergyLogDomainService>();

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
