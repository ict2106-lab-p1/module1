using LivingLab.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LivingLab.Infrastructure.Data.Config;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class EnergyUsageLogConfig : IEntityTypeConfiguration<EnergyUsageLog>
{
    public void Configure(EntityTypeBuilder<EnergyUsageLog> builder)
    {
        builder.Property(log => log.Interval)
            .HasConversion(new TimeSpanToTicksConverter());
    }
}
