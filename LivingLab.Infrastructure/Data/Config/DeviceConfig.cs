using LivingLab.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivingLab.Infrastructure.Data.Config;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class DeviceConfig : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.HasOne(d => d.Lab)
            .WithMany(l => l.Devices)
            .HasForeignKey("LabId");
    }
}
