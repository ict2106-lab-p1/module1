using LivingLab.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivingLab.Infrastructure.Data.Config;

/// <remarks>
/// Author: Team P1-3
/// </remarks>
public class AccessoryConfig: IEntityTypeConfiguration<Accessory>
{
    public void Configure(EntityTypeBuilder<Accessory> builder)
    {
        builder.HasOne(a => a.Lab)
            .WithMany(l => l.Accessories)
            .HasForeignKey("LabId");
        builder.HasOne(a => a.AccessoryType)
            .WithMany(l => l.Accessories)
            .HasForeignKey("AccessoryTypeId");
    }
}
