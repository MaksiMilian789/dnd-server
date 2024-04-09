using DndServer.Domain.Character.Background;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Character.Background;

public class BackgroundInstanceConfiguration : IEntityTypeConfiguration<BackgroundInstance>
{
    public void Configure(EntityTypeBuilder<BackgroundInstance> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Character).WithOne(x => x.BackgroundInstance);
    }
}