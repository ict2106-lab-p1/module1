using LivingLab.Core.DomainServices;
using LivingLab.Core.Entities.Identity;
using LivingLab.Core.Interfaces.Repositories;
using LivingLab.Core.Interfaces.Services;
using LivingLab.Infrastructure.Data;
using LivingLab.Infrastructure.InfraServices;
using LivingLab.Infrastructure.Repositories;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LivingLab.Infrastructure.Configuration;

/// <summary>
/// This is the BASE configuration class for dependency injection and any additional services in the CORE PROJECT.
/// You should not need to touch this file.
///
/// Team P1-1 & P1-2: Inject into ConfigureEnergyMonitoringServices.cs
/// Team P1-3 & P1-5: Inject into ConfigureManagementServices.cs
/// </summary>
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
        services.AddEnergyMonitoringServices();
        services.AddManagementServices();

        services.AddTransient<ITodoRepository, TodoRepository>();
        services.AddTransient<ITodoDomainService, TodoDomainService>();
        services.AddTransient<IEmailSender, EmailSender>();

        return services;
    }


}
