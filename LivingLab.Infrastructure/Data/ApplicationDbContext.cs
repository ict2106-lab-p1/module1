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
        // Devices and Device Types
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

        // Accessory and Accessory Types
        modelBuilder.Entity<AccessoryType>().HasData(
        new { Id = 1, Name = "Camera", Cost = 499.0, Borrowable = true, Description = "It''s purpose is to capture images and videos" },
        new { Id = 2, Name = "Ultrasonic Sensor", Borrowable = true, Cost = 1.0, Description = "It''s purpose is to detect obstacles"},
        new { Id = 3, Name = "Humidity Sensor", Borrowable = true, Cost = 3.0, Description = "It''s purpose is to detect humidity in the environment"},
        new { Id = 4, Name = "Water pressure Sensor", Borrowable = true, Cost = 7.0, Description = "It''s purpose is to detect water pressure"},
        new { Id = 5, Name = "IR Sensor", Borrowable = true, Cost = 2.0, Description = "It is used to switch on the lights in the lab"},
        new { Id = 6, Name = "Proximity Sensor", Borrowable = true, Cost = 14.0, Description = "It''s purpose is to detect proximity of an obstacle"},
        new { Id = 7, Name = "LED Lights", Borrowable = false, Cost = 10.0, Description = "It''s purpose is to emit light"},
        new { Id = 8, Name = "Buzzer", Borrowable = true, Cost = 1.0, Description = "It''s purpose is to emit sound from the device"}
        );

        modelBuilder.Entity<Accessory>(entity => {
                entity.HasOne(a => a.Lab)
                .WithMany(l => l.Accessories)
                .HasForeignKey("LabId");
                entity.HasOne(a => a.AccessoryType)
                .WithMany(l => l.Accessories)
                .HasForeignKey("AccessoryTypeId");
        });

        modelBuilder.Entity<Accessory>().HasData(
                new { Id = 1, status = "Available", ValidityDate = new DateTime(2024,10,10),  LabId = 1, AccessoryTypeId = 1},
                new { Id = 2, status = "Borrowed", ValidityDate = new DateTime(2024,10,14),  LabId = 1, AccessoryTypeId = 1},
                new { Id = 3, status = "Available", ValidityDate = new DateTime(2024,10,17),  LabId = 1, AccessoryTypeId = 2},
                new { Id = 4, status = "Available", ValidityDate = new DateTime(2024,10,21), LabId = 1, AccessoryTypeId = 2},
                new { Id = 5, status = "Borrowed", ValidityDate = new DateTime(2024,9,9), LabId = 1, AccessoryTypeId = 3},
                new { Id = 6, status = "Available", ValidityDate = new DateTime(2024,9,5),  LabId = 1, AccessoryTypeId = 3},
                new { Id = 7, status = "Available", ValidityDate = new DateTime(2024,8,1),  LabId = 1, AccessoryTypeId = 4},
                new { Id = 8, status = "Borrowed", ValidityDate = new DateTime(2024,8,10),  LabId = 1, AccessoryTypeId = 4},
                new { Id = 9, status = "Available", ValidityDate = new DateTime(2024,7,3),  LabId = 1, AccessoryTypeId = 5},
                new { Id = 10, status = "Borrowed", ValidityDate = new DateTime(2024,6,24),  LabId = 1, AccessoryTypeId = 5},
                new { Id = 11, status = "Available", ValidityDate = new DateTime(2024,7,25),  LabId = 1, AccessoryTypeId = 6},
                new { Id = 12, status = "Available", ValidityDate = new DateTime(2024,4,3),  LabId = 1, AccessoryTypeId = 6},
                new { Id = 13, status = "Borrowed", ValidityDate = new DateTime(2024,7,19),  LabId = 1, AccessoryTypeId = 7},
                new { Id = 14, status = "Brrowed", ValidityDate = new DateTime(2024,12,14),  LabId = 1, AccessoryTypeId = 7},
                new { Id = 15, status = "Available", ValidityDate = new DateTime(2024,11,12),  LabId = 1, AccessoryTypeId = 8},
                new { Id = 16, status = "Available", ValidityDate = new DateTime(2024,7,3),  LabId = 1, AccessoryTypeId = 8}
        );

    }

}