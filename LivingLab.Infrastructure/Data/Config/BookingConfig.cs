using LivingLab.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivingLab.Infrastructure.Data.Config;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class BookingConfig : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Booking");
        builder.HasOne(b => b.Lab)
            .WithMany(l => l.Bookings)
            .HasForeignKey("LabId")
            .HasPrincipalKey("LabId");
        builder.HasOne(b => b.ApplicationUser)
            .WithMany(a => a.Bookings)
            .HasForeignKey(b => b.UserId)
            .HasPrincipalKey(a => a.Id);
    }
}
