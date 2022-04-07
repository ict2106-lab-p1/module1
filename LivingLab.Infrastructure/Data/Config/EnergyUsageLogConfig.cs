using LivingLab.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LivingLab.Infrastructure.Data.Config;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class EnergyUsageLogConfig : IEntityTypeConfiguration<EnergyUsageLog>
{
    /// <remarks>
    /// store time intervals as long int ticks
    /// </remarks>
    public void Configure(EntityTypeBuilder<EnergyUsageLog> builder)
    {
        builder.Property(log => log.Interval)
            .HasConversion(new TimeSpanToTicksConverter());
    }
}
