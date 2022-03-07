using LivingLab.Domain.Entities.Identity;
using LivingLab.Domain.Interfaces.Repositories;
using LivingLab.Infrastructure.Data;
using LivingLab.Infrastructure.Repositories;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LivingLab.Infrastructure.Extensions;

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

    public static void AddTransientServices(this IServiceCollection services)
    {
        services.AddTransient<ITodoRepository, TodoRepository>();
        services.AddTransient<IAccessoryRepository, AccessoryRepository>();
        services.AddTransient<IAccessoryTypeRepository, AccessoryTypeRepository>();
        services.AddTransient<IDeviceRepository, DeviceRepository>();
        services.AddTransient<ILabRepository, LabRepository>();
        services.AddTransient<ILoggingRepository, LoggingRepository>();
    }

    public static void AddScopedServices(this IServiceCollection services)
    {
        // services.AddScoped<ITodoRepository, TodoRepository>();
    }


}
