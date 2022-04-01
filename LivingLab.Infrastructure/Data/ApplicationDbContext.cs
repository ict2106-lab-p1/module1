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
    public DbSet<Lab> Labs { get; set; }
    public DbSet<Device> Devices { get; set; }
    
    public DbSet<EnergyUsageLog> EnergyUsageLogs { get; set; }
    public DbSet<PowerGenerationMix> PowerGenerationMix { get; set; }
    public DbSet<CarbonFootprintEstimation> CarbonFootprintEstimations { get; set; }
    public DbSet<SmsLog> SmsLogs { get; set; }
    public DbSet<EmailLog> EmailLogs { get; set; }
    public DbSet<Accessory> Accessories { get; set; }
    public DbSet<SessionStats> SessionStats { get; set; }
    public DbSet<AccessoryType> AccessoryTypes { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<LabAccess> LabAccesses { get; set; }
    public DbSet<Lab> LabProfile { get; set; }

    public DbSet<ApplicationUser> Users { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // More info: https://docs.microsoft.com/en-us/ef/core/modeling/
        new TodoConfig().Configure(modelBuilder.Entity<Todo>());
        // new EnergyUsageLogConfiguration().Configure(modelBuilder.Entity<EnergyUsageLog>());
        new NotificationsConfig().Configure(modelBuilder.Entity<ApplicationUser>());
        new AccessoryConfig().Configure(modelBuilder.Entity<Accessory>());
        new BookingConfig().Configure(modelBuilder.Entity<Booking>());
        new DeviceConfig().Configure(modelBuilder.Entity<Device>());
        new LabAccessConfig().Configure(modelBuilder.Entity<LabAccess>());
        new LabConfig().Configure(modelBuilder.Entity<Lab>());

        // Rename ASP.NET Identity tables
        modelBuilder.Entity<ApplicationUser>(e => e.ToTable("Users"));
        modelBuilder.Entity<IdentityRole>(e => e.ToTable("Role"));
        modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
        modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
        modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
        modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserToken");

        modelBuilder.Seed();

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasOne(d => d.Lab)
            .WithMany(l => l.Devices)
            .HasForeignKey("LabId");
        });

        modelBuilder.Entity<Accessory>(entity =>
        {
            entity.HasOne(a => a.Lab)
            .WithMany(l => l.Accessories)
            .HasForeignKey("LabId");
            entity.HasOne(a => a.AccessoryType)
            .WithMany(l => l.Accessories)
            .HasForeignKey("AccessoryTypeId");
        });

    }

}
