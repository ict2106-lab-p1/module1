using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;
using LivingLab.Infrastructure.Data.Config;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace LivingLab.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    // Add new DB tables here
    public DbSet<Todo> Todos { get; set; }
    public DbSet<Accessory> Accessory { get; set; }
    public DbSet<Device> Device { get; set; }
    // public DbSet<DeviceType> DeviceType { get; set; }
    public DbSet<Lab> Lab { get; set; }
    public DbSet<SessionStats> SessionStats { get; set; }
    public DbSet<AccessoryType> AccessoryType { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // More info: https://docs.microsoft.com/en-us/ef/core/modeling/
        new TodoConfiguration().Configure(modelBuilder.Entity<Todo>());

        // Rename ASP.NET Identity tables
        modelBuilder.Entity<ApplicationUser>(e => e.ToTable("Users"));
        modelBuilder.Entity<IdentityRole>(e => e.ToTable("Role"));
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserToken");

        modelBuilder.Seed();
    }

}
