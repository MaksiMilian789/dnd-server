using DndServer.Domain.Worlds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Worlds;

public class WorldLinksConfiguration : IEntityTypeConfiguration<WorldLinks>
{
    public void Configure(EntityTypeBuilder<WorldLinks> builder) =>
        builder.HasKey(x => x.Id);
}