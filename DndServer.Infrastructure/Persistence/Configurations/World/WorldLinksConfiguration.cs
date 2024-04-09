using DndServer.Domain.World;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.World;

public class WorldLinksConfiguration : IEntityTypeConfiguration<WorldLinks>
{
    public void Configure(EntityTypeBuilder<WorldLinks> builder) =>
        builder.HasKey(x => x.Id);
}