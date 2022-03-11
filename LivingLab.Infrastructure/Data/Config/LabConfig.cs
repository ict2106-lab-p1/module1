using LivingLab.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivingLab.Infrastructure.Data.Config;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabConfig : IEntityTypeConfiguration<Lab>
{
    public void Configure(EntityTypeBuilder<Lab> builder)
    {
        builder.ToTable("Labs");
        builder.HasOne(l => l.ApplicationUser)
            .WithMany(a => a.Labs)
            .HasForeignKey(l=>l.LabInCharge)
            .HasPrincipalKey(a=>a.Id);
    }
}
