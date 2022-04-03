using LivingLab.Core.DomainServices;
using LivingLab.Core.Entities.Secrets;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Infrastructure.Repositories;

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
        services.AddTransient<ILabRepository, LabRepository>();
        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<ILabProfileRepository, LabProfileRepository>();
        services.AddTransient<IBookingRepository, BookingRepository>();

        // Services
        services.AddTransient<IDeviceDomainService, DeviceDomainService>();
        services.AddTransient<IAccessoryDomainService, AccessoryDomainService>();
        services.AddTransient<IAccountDomainService, AccountDomainService>();
        services.AddTransient<ILabProfileDomainService, LabProfileDomainService>();
        services.AddTransient<IBookingDomainService, BookingDomainService>();
        services.AddTransient<ILabAccessDomainService, LabAccessDomainService>();
        services.AddTransient<ISessionStatsDomainService, SessionStatsDomainService>();
        services.AddTransient<ILivingLabDashboardDomainService, LivingLabDashboardDomainService>();


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
