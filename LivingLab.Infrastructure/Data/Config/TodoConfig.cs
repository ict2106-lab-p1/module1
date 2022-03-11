using LivingLab.Core.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivingLab.Infrastructure.Data.Config;

public class TodoConfig : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        //builder.Property(t => t.Title).IsRequired();
        
    }
}
