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
    }
}
