using LivingLab.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivingLab.Infrastructure.Data.Config;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class LabAccessConfig : IEntityTypeConfiguration<LabAccess>
{
    public void Configure(EntityTypeBuilder<LabAccess> builder)
    {
        builder.ToTable("LabAccess");
        builder.HasKey(l => new {l.UserId, l.LabId});
        builder.HasOne(l => l.ApplicationUser)
            .WithMany(a => a.LabAccesses)
            .HasForeignKey(l=>l.UserId)
            .HasPrincipalKey(a=>a.Id);
        builder.HasOne(l => l.ApplicationUser)
            .WithMany(a => a.LabAccesses)
            .HasForeignKey(l=>l.InitiatorId)
            .HasPrincipalKey(a=>a.Id);
    }
}
