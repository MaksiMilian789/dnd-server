using DndServer.Domain.Worlds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Worlds;

public class WikiConfiguration : IEntityTypeConfiguration<Wiki>
{
    public void Configure(EntityTypeBuilder<Wiki> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.WikiPage).WithOne(x => x.Wiki);
        builder.HasOne(x => x.World).WithOne(x => x.Wiki).HasForeignKey<World>(x => x.WikiKey);
    }
}