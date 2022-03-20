using LivingLab.Core.Constants;
using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;

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
        //Add Dummy Data
        // Devices and Device Types
        // modelBuilder.Entity<Labs>().HasData(
        // new { Id = 1, Location = "NYP-SR7C", PersonInCharge = "David", LabStatus ="Available"}
        // );

        modelBuilder.Entity<ApplicationUser>().HasData(
            new { Id = "UserId1", UserId = 1, FirstName = "David", LastName = "Cheng", PhoneNumber = "96878607", Email = "David@gmail.com", TwoFactorEnabled = false, AuthenticationType = "None", PasswordHash = "testtesttest", SMSExpiry = new DateTime(2022, 7, 19, hour: 12, minute: 00, second: 00), UserFaculty = "ICT", AccessFailedCount = 0, LockoutEnabled = true, EmailConfirmed = false, PhoneNumberConfirmed = false },
            new { Id = "UserId2", UserId = 2, FirstName = "Carlton", LastName = "Foo", PhoneNumber = "12341234", Email = "henry@gmail.com", TwoFactorEnabled = false, AuthenticationType = "None", PasswordHash = "testtesttest", SMSExpiry = new DateTime(2022, 7, 19, hour: 12, minute: 00, second: 00), UserFaculty = "SE", AccessFailedCount = 0, LockoutEnabled = true, EmailConfirmed = false, PhoneNumberConfirmed = false },
            new { Id = "UserId3", UserId = 3, FirstName = "Hou Liang", LastName = "Yip", PhoneNumber = "80808080", Email = "houliang@gmail.com", TwoFactorEnabled = false, AuthenticationType = "None", PasswordHash = "testtesttest", SMSExpiry = new DateTime(2022, 7, 19, hour: 12, minute: 00, second: 00), UserFaculty = "SE", AccessFailedCount = 0, LockoutEnabled = true, EmailConfirmed = false, PhoneNumberConfirmed = false }
        );

        modelBuilder.Entity<Lab>().HasData(
            new { LabId = 1, LabLocation = "NYP-SR7C", LabInCharge = "UserId1", LabStatus = "Available", Capacity = 20 }
        );

        modelBuilder.Entity<LabAccess>().HasData(
            new { UserId = "UserId2", LabId = 1, InitiatorId = "UserId1" }
        );

        modelBuilder.Entity<Booking>().HasData(
            new { BookingId = 1, StartDateTime = new DateTime(2022, 7, 19, hour: 10, minute: 00, second: 00), EndDateTime = new DateTime(2022, 7, 19, hour: 12, minute: 00, second: 00), LabId = 1, UserId = "UserId3" }
        );

        modelBuilder.Entity<Device>().HasData(
                new { Id = 1, Name = "Surveillance Camera", LastUpdated = new DateTime(2020, 10, 10), SerialNo = "SC1001", LabId = 1, Status = "Available", Type = "Surveillance Camera", Description = "Its purpose is to detect situation in the laboratory" , ReviewStatus = "Pending", ReviewedBy = "David"},
                new { Id = 2, Name = "Temperature Sensor", LastUpdated = new DateTime(2020, 10, 11), SerialNo = "R1001", LabId = 1, Status = "Available", Type = "Temperature Sensor", Description = "Its purpose is to detect temperature in the laboratory", ReviewStatus = "Approved", ReviewedBy = "David"},
                new { Id = 3, Name = "Humidity Sensor", LastUpdated = new DateTime(2020, 9, 9), SerialNo = "S1001", LabId = 1, Status = "Available", Type = "Humidity Sensor", Description = "Its purpose is to detect humidity in the laboratory", ReviewStatus = "Approved", ReviewedBy = "David" },
                new { Id = 4, Name = "Light Sensor", LastUpdated = new DateTime(2019, 8, 1), SerialNo = "SL1001", LabId = 1, Status = "Available", Type = "Light Sensor", Description = "Its purpose is to detect light in the laboratory", ReviewStatus = "Rejected", ReviewedBy = "David" },
                new { Id = 5, Name = "VR Light Controls", LastUpdated = new DateTime(2019, 7, 3), SerialNo = "VRL1001", LabId = 1, Status = "Unavailable", Type = "VR Light Controls", Description = "It is used to control brightness of the lights in the lab", ReviewStatus = "Pending" , ReviewedBy = "David"}
        );

        // Accessory and Accessory Types
        modelBuilder.Entity<AccessoryType>().HasData(
                new { Id = 1, Type = "Camera", Borrowable = true, Name = "Sony A7 IV", Description = "Its purpose is to capture images and videos" },
                new { Id = 2, Type = "Ultrasonic Sensor", Borrowable = true, Name = "MA300D1-1", Description = "Its purpose is to detect obstacles" },
                new { Id = 3, Type = "Humidity Sensor", Borrowable = true, Name = "DHT22", Description = "Its purpose is to detect humidity in the environment" },
                new { Id = 4, Type = "Water pressure Sensor", Borrowable = true, Name = "LEFOO LFT2000W", Description = "Its purpose is to detect water pressure" },
                new { Id = 5, Type = "IR Sensor", Borrowable = true, Name = "RM1802", Description = "It is used to switch on the lights in the lab" },
                new { Id = 6, Type = "Proximity Sensor", Borrowable = true, Name = "HC-SR04", Description = "Its purpose is to detect proximity of an obstacle" },
                new { Id = 7, Type = "LED Lights", Borrowable = false, Name = "EDGELEC 4Pin LED Diodes", Description = "Its purpose is to emit light" },
                new { Id = 8, Type = "Buzzer", Borrowable = true, Name = "TMB09A05", Description = "Its purpose is to emit sound from the device" }
        );

        modelBuilder.Entity<Accessory>().HasData(
                new { Id = 1, Status = "Available", LastUpdated = new DateTime(2021, 10, 10), LabId = 1, AccessoryTypeId = 1 , ReviewStatus = "Pending" , ReviewedBy = "David"},
                new { Id = 2, Status = "Borrowed", LastUpdated = new DateTime(2021, 10, 14), LabId = 1, AccessoryTypeId = 1, LabUserId = "User1", DueDate = new DateTime(2022, 10, 14), ReviewStatus = "Pending" , ReviewedBy = "David" },
                new { Id = 3, Status = "Available", LastUpdated = new DateTime(2021, 10, 17), LabId = 1, AccessoryTypeId = 2, ReviewStatus = "Pending" , ReviewedBy = "David" },
                new { Id = 4, Status = "Available", LastUpdated = new DateTime(2021, 10, 21), LabId = 1, AccessoryTypeId = 2, ReviewStatus = "Pending" , ReviewedBy = "David" },
                new { Id = 5, Status = "Borrowed", LastUpdated = new DateTime(2021, 9, 9), LabId = 1, AccessoryTypeId = 3, LabUserId = "User1", DueDate = new DateTime(2022, 9, 9) , ReviewStatus = "Pending" , ReviewedBy = "David"},
                new { Id = 6, Status = "Available", LastUpdated = new DateTime(2021, 9, 5), LabId = 1, AccessoryTypeId = 3 , ReviewStatus = "Pending" , ReviewedBy = "David"},
                new { Id = 7, Status = "Available", LastUpdated = new DateTime(2021, 8, 1), LabId = 1, AccessoryTypeId = 4 , ReviewStatus = "Pending" , ReviewedBy = "David"},
                new { Id = 8, Status = "Borrowed", LastUpdated = new DateTime(2021, 8, 10), LabId = 1, AccessoryTypeId = 4, LabUserId = "User1", DueDate = new DateTime(2022, 9, 5) , ReviewStatus = "Pending" , ReviewedBy = "David"},
                new { Id = 9, Status = "Available", LastUpdated = new DateTime(2021, 7, 3), LabId = 1, AccessoryTypeId = 5 , ReviewStatus = "Pending" , ReviewedBy = "David"},
                new { Id = 10, Status = "Borrowed", LastUpdated = new DateTime(2021, 6, 24), LabId = 1, AccessoryTypeId = 5, LabUserId = "User1", DueDate = new DateTime(2022, 10, 14) , ReviewStatus = "Pending" , ReviewedBy = "David"},
                new { Id = 11, Status = "Available", LastUpdated = new DateTime(2021, 7, 25), LabId = 1, AccessoryTypeId = 6, ReviewStatus = "Pending" , ReviewedBy = "David"},
                new { Id = 12, Status = "Available", LastUpdated = new DateTime(2021, 4, 3), LabId = 1, AccessoryTypeId = 6 , ReviewStatus = "Pending" , ReviewedBy = "David"},
                new { Id = 13, Status = "Borrowed", LastUpdated = new DateTime(2021, 7, 19), LabId = 1, AccessoryTypeId = 7, LabUserId = "User1", DueDate = new DateTime(2022, 7, 19) , ReviewStatus = "Pending" , ReviewedBy = "David"},
                new { Id = 14, Status = "Borrowed", LastUpdated = new DateTime(2021, 12, 14), LabId = 1, AccessoryTypeId = 7, LabUserId = "user1", DueDate = new DateTime(2022, 12, 14), ReviewStatus = "Pending" , ReviewedBy = "David" },
                new { Id = 15, Status = "Available", LastUpdated = new DateTime(2021, 11, 12), LabId = 1, AccessoryTypeId = 8 , ReviewStatus = "Pending" , ReviewedBy = "David"},
                new { Id = 16, Status = "Available", LastUpdated = new DateTime(2021, 7, 3), LabId = 1, AccessoryTypeId = 8 , ReviewStatus = "Pending" , ReviewedBy = "David"}
        );

        modelBuilder.Entity<SessionStats>().HasData(
                new { Id = 1, Date = new DateTime(2021,7,3), LoginTime = new DateTime(2021, 7, 3, 9,0,0), LogoutTime = new DateTime(2021, 7, 3, 12,0,0), DataUploaded= 58.0, LabId=1},
                new { Id = 2, Date = new DateTime(2021,7,4), LoginTime = new DateTime(2021, 7, 4, 10,0,0), LogoutTime = new DateTime(2021, 7, 4, 15,0,0), DataUploaded= 64.0, LabId=1},
                new { Id = 3, Date = new DateTime(2021,7,5), LoginTime = new DateTime(2021, 7, 5, 13,0,0), LogoutTime = new DateTime(2021, 7, 5, 18,0,0), DataUploaded= 128.0, LabId=1}
        );
    }
}
