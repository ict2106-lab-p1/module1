using LivingLab.Core.Entities;
using LivingLab.Core.Entities.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivingLab.Infrastructure.Data.Config;

/// <remarks>
/// Author: Team P1-5
/// </remarks>
public class NotificationsConfig : IEntityTypeConfiguration<ApplicationUser>
{
    /// <remarks>
    /// this is needed to force EF to recognize many-to-many relationship
    /// otherwise it just autogenerates a one-to-many relationship
    /// </remarks>
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasMany<EmailLog>("NotificationEmails")
            .WithMany(email => email.Users);
    }
}
