using LivingLab.Core.Constants;
using LivingLab.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Data;

public static class DataSeeder
{
    /// <summary>
    /// This is where you add your seed data.
    /// This method has been called in the ApplicationDbContext class.
    /// </summary>
    /// <param name="modelBuilder"></param>
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // Add your seed data here.
        // You can add seed data for specific tables here if you need to.
        // You can also create entities and add them directly here if you need to.
        // modelBuilder.Entity<YourEntity>().HasData(new YourEntity { Id = 1, Name = "Your New Entity" });
        modelBuilder.Entity<Device>().HasData(
            new Device { Id = 1, DeviceSerialNumber = "DEVICE-3390", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber() },
            new Device { Id = 2, DeviceSerialNumber = "DEVICE-6049", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber() },
            new Device { Id = 3, DeviceSerialNumber = "DEVICE-1598", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber() },
            new Device { Id = 4, DeviceSerialNumber = "DEVICE-1232", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber() },
            new Device { Id = 5, DeviceSerialNumber = "DEVICE-1123", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber() },
            new Device { Id = 6, DeviceSerialNumber = "DEVICE-8987", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber() },
            new Device { Id = 7, DeviceSerialNumber = "DEVICE-2435", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber() },
            new Device { Id = 8, DeviceSerialNumber = "DEVICE-1234", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber() },
            new Device { Id = 9, DeviceSerialNumber = "DEVICE-5423", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber() },
            new Device { Id = 10, DeviceSerialNumber = "DEVICE-7452", Type = DeviceTypes.SMART_SENSOR, EnergyUsageThreshold = GetRandomNumber() }
        );

        modelBuilder.Entity<Lab>().HasData(
            new Lab { Id = 1, Area = 12 },
            new Lab { Id = 2, Area = 12 },
            new Lab { Id = 3, Area = 12 },
            new Lab { Id = 4, Area = 12 }
        );
    }

    private static int GetRandomNumber()
    {
        var random = new Random();
        return random.Next(1000, 9999);
    }
}
