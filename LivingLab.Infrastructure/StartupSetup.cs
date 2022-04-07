using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LivingLab.Infrastructure;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public static class StartupSetup
{
    public static void AddDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
}
