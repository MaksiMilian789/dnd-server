using DndServer.Domain.Worlds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Worlds;

public class TrackerUnitConfiguration : IEntityTypeConfiguration<TrackerUnit>
{
    public void Configure(EntityTypeBuilder<TrackerUnit> builder)
    {
        builder.HasKey(x => x.Id);
    }
}