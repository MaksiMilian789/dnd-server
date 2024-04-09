using DndServer.Domain.Character.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Character.Inventory;

public class ObjectInstanceConfiguration : IEntityTypeConfiguration<ObjectInstance>
{
    public void Configure(EntityTypeBuilder<ObjectInstance> builder) =>
        builder.HasKey(x => x.Id);
}