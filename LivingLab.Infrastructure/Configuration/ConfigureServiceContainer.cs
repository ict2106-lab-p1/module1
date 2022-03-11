using LivingLab.Core.DomainServices;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Infrastructure.Data;
<<<<<<< HEAD
using LivingLab.Infrastructure.InfraServices;
using LivingLab.Infrastructure.InfraServices.CsvParser;
=======
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
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
<<<<<<< HEAD

    private static IServiceCollection AddTransientServices(this IServiceCollection services)
    {
        // Repositories
        services.AddTransient<ITodoRepository, TodoRepository>();
        services.AddTransient<IEnergyUsageRepository, EnergyUsageRepository>();
        services.AddTransient<ISmsRepository, SmsRepository>();
        services.AddTransient<IEmailRepository, EmailRepository>();
        services.AddTransient<IPowerGenerationMixRepository, PowerGenerationMixRepository>();
=======
    
    private static IServiceCollection AddTransientServices(this IServiceCollection services)
    {
        services.AddTransient<ITodoRepository, TodoRepository>();
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
        services.AddTransient<IAccessoryRepository, AccessoryRepository>();
        services.AddTransient<IAccessoryTypeRepository, AccessoryTypeRepository>();
        services.AddTransient<IDeviceRepository, DeviceRepository>();
        services.AddTransient<ISessionStatsRepository, SessionStatsRepository>();
<<<<<<< HEAD

        // Services
        services.AddTransient<ITodoDomainService, TodoDomainService>();
        services.AddTransient<IEnergyUsageLogCsvParser, EnergyUsageLogCsvParser>();
        services.AddTransient<IExportData, ExportData>();
        services.AddTransient<IEnergyUsageService, EnergyUsageService>();
        services.AddTransient<IManualLogDomainService, ManualLogDomainService>();
        services.AddTransient<INotificationDomainService, NotificationDomainService>();
        services.AddTransient<IDeviceDomainService, DeviceDomainService>();
        services.AddTransient<IAccessoryDomainService, AccessoryDomainService>();
        services.AddTransient<IEnergyLogDomainService, EnergyLogDomainService>();


=======
        services.AddTransient<IAccessoryDomainService, AccessoryDomainService>();
        services.AddTransient<IDeviceDomainService, DeviceDomainService>();
        services.AddTransient<ITodoDomainService, TodoDomainService>();
        
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
        return services;
    }

    private static IServiceCollection AddScopedServices(this IServiceCollection services)
    {
        // services.AddScoped<ITodoRepository, TodoRepository>();

        return services;
    }
<<<<<<< HEAD
=======
    
>>>>>>> e90249168d4bcb9fce4bbd09def560c9e7bc34e9
    private static IServiceCollection AddSingletonServices(this IServiceCollection services)
    {
        // services.AddSingleton<ITodoRepository, TodoRepository>();

        return services;
    }


}
