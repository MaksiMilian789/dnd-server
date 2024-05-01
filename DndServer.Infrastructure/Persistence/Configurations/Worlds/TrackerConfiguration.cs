using DndServer.Domain.Worlds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Worlds;

public class TrackerConfiguration : IEntityTypeConfiguration<Tracker>
{
    public void Configure(EntityTypeBuilder<Tracker> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.World).WithOne(x => x.Tracker).HasForeignKey<World>(x => x.TrackerKey);
        builder.HasMany(x => x.TrackerUnits).WithOne(x => x.Tracker);
    }
}