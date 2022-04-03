using LivingLab.Core.DomainServices;
using LivingLab.Core.DomainServices.Account;
using LivingLab.Core.DomainServices.Account.Session;
using LivingLab.Core.DomainServices.Equipment;
using LivingLab.Core.DomainServices.Equipment.Accessory;
using LivingLab.Core.DomainServices.Equipment.Device;
using LivingLab.Core.DomainServices.Lab;
using LivingLab.Core.Repositories.Account;
using LivingLab.Core.Repositories.Equipment;
using LivingLab.Core.Repositories.Lab;
using LivingLab.Infrastructure.Repositories;
using LivingLab.Infrastructure.Repositories.Account;
using LivingLab.Infrastructure.Repositories.Equipment;
using LivingLab.Infrastructure.Repositories.Lab;

using Microsoft.Extensions.DependencyInjection;

namespace LivingLab.Infrastructure.Configuration;

/// <summary>
/// Team P1-3 & P1-5 to add dependency injections for mod 1 here.
/// </summary>
public static class ConfigureManagementServices
{
    public static IServiceCollection AddManagementServices(this IServiceCollection services)
    {
        AddTransientServices(services);
        AddScopedServices(services);
        AddSingletonServices(services);
        return services;
    }

    private static IServiceCollection AddTransientServices(this IServiceCollection services)
    {
        // Repositories
        services.AddTransient<IAccessoryRepository, AccessoryRepository>();
        services.AddTransient<IAccessoryTypeRepository, AccessoryTypeRepository>();
        services.AddTransient<IDeviceRepository, DeviceRepository>();
        services.AddTransient<ISessionStatsRepository, SessionStatsRepository>();
        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<ILabProfileRepository, LabProfileRepository>();
        services.AddTransient<IBookingRepository, BookingRepository>();

        // Services
        services.AddTransient<IDeviceDomainService, DeviceDomainService>();
        services.AddTransient<IAccessoryDomainService, AccessoryDomainService>();
        services.AddTransient<IAccountDomainService, AccountDomainService>();
        services.AddTransient<ILabProfileDomainService, LabProfileDomainService>();
        services.AddTransient<IBookingDomainService, BookingDomainService>();
        services.AddTransient<ISessionStatsDomainService, SessionStatsDomainService>();

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
