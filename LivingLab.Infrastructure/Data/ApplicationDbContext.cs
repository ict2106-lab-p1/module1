using LivingLab.Domain.Entities;
using LivingLab.Domain.Entities.Identity;
using LivingLab.Infrastructure.Data.Config;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    // Add new DB tables here
    public DbSet<Todo> Todos { get; set; }
    public DbSet<Accessory> Accessory { get; set; }
    public DbSet<Device> Device { get; set; }
    public DbSet<DeviceType> DeviceType { get; set; }
    public DbSet<Lab> Lab { get; set; }
    public DbSet<Report> Report { get; set; }
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

        //Add Dummy Data
        modelBuilder.Entity<Lab>().HasData(
        new { Id = 1, Location = "NYP-SR7C", PersonInCharge = "David", LabStatus ="Available"}
        );

        modelBuilder.Entity<DeviceType>().HasData(
        new { Id = 1, Name = "Surveillance Camera", Description = "It''s purpose is to detect situation in the laboratory", Cost = 499.0 },
        new { Id = 2, Name = "Temperature Sensor", Description = "It''s purpose is to detect temperature in the laboratory", Cost = 130.0 },
        new { Id = 3, Name = "Humidity Sensor", Description = "It''s purpose is to detect humidity in the laboratory", Cost = 130.0 },
        new { Id = 4, Name = "Light Sensor", Description = "It''s purpose is to detect light in the laboratory", Cost = 320.0 },
        new { Id = 5, Name = "VR Light Controls", Description = "It is used to control brightness of the lights in the lab", Cost = 323.0 }
        );

        modelBuilder.Entity<Device>(entity => { 
                entity.HasOne(d => d.Lab)
                .WithMany(l => l.Devices)
                .HasForeignKey("LabId");
                entity.HasOne(d => d.DeviceType)
                .WithMany(l => l.Devices)
                .HasForeignKey("DeviceTypeId");
        });

        modelBuilder.Entity<Device>().HasData(
                new { Id = 1, ValidityDate = new DateTime(2020,10,10), SerialNo = "SC1001", LabId = 1, DeviceTypeId = 1},
                new { Id = 2, ValidityDate = new DateTime(2020,10,11), SerialNo = "R1001", LabId = 1, DeviceTypeId = 2},
                new { Id = 3, ValidityDate = new DateTime(2020,9,9), SerialNo = "S1001", LabId = 1, DeviceTypeId = 3},
                new { Id = 4, ValidityDate = new DateTime(2019,8,1), SerialNo = "SL1001", LabId = 1, DeviceTypeId = 4},
                new { Id = 5, ValidityDate = new DateTime(2019,7,3), SerialNo = "VRL1001", LabId = 1, DeviceTypeId = 5}
        );

    }

}