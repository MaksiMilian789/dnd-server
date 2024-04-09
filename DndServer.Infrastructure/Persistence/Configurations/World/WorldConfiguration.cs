using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.World;

public class WorldConfiguration : IEntityTypeConfiguration<Domain.World.World>
{
    public void Configure(EntityTypeBuilder<Domain.World.World> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.WorldLinks).WithOne(x => x.World);
    }
}