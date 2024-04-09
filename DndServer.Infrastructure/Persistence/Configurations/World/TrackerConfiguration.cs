using DndServer.Domain.World;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.World;

public class TrackerConfiguration : IEntityTypeConfiguration<Tracker>
{
    public void Configure(EntityTypeBuilder<Tracker> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.World).WithOne(x => x.Tracker);
    }
}