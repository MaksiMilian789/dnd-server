using DndServer.Domain.Character.Race;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Character.Race;

public class RaceInstanceConfiguration : IEntityTypeConfiguration<RaceInstance>
{
    public void Configure(EntityTypeBuilder<RaceInstance> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Character).WithOne(x => x.RaceInstance);
    }
}