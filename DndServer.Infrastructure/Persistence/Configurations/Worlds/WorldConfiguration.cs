using DndServer.Domain.Worlds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Worlds;

public class WorldConfiguration : IEntityTypeConfiguration<World>
{
    public void Configure(EntityTypeBuilder<World> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.WorldLinks).WithOne(x => x.World).HasForeignKey(x => x.WorldId);
        builder.HasMany(x => x.Wiki).WithOne(x => x.World).HasForeignKey(x => x.WorldId);
    }
}