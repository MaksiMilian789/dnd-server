using DndServer.Domain.Characters.Race;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters.Race;

public class RaceInstanceConfiguration : IEntityTypeConfiguration<RaceInstance>
{
    public void Configure(EntityTypeBuilder<RaceInstance> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Character).WithOne(x => x.RaceInstance).HasForeignKey(x => x.RaceInstanceId);
    }
}