using LivingLab.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LivingLab.Infrastructure.Data.Config;

public class EnergyUsageLogConfiguration : IEntityTypeConfiguration<EnergyUsageLog>
{
    public void Configure(EntityTypeBuilder<EnergyUsageLog> builder)
    {
        builder.Property(log => log.Interval)
            .HasConversion(new TimeSpanToTicksConverter());
    }
}
