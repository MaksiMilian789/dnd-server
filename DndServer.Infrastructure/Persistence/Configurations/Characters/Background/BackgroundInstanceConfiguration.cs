using DndServer.Domain.Characters.Background;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters.Background;

public class BackgroundInstanceConfiguration : IEntityTypeConfiguration<BackgroundInstance>
{
    public void Configure(EntityTypeBuilder<BackgroundInstance> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Character).WithOne(x => x.BackgroundInstance).HasForeignKey(x => x.BackgroundInstanceId);
    }
}