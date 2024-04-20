using DndServer.Domain.Characters.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters.Inventory;

public class ObjectTemplateConfiguration : IEntityTypeConfiguration<ObjectTemplate>
{
    public void Configure(EntityTypeBuilder<ObjectTemplate> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ComplexProperty(x => x.Damage, b =>
        {
            b.ComplexProperty(z => z.DamageRoll);
            b.ComplexProperty(z => z.Type);
        });
    }
}