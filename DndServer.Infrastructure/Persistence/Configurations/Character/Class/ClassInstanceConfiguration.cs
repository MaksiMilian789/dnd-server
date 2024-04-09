using DndServer.Domain.Character.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Character.Class;

public class ClassInstanceConfiguration : IEntityTypeConfiguration<ClassInstance>
{
    public void Configure(EntityTypeBuilder<ClassInstance> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Character).WithOne(x => x.ClassInstance);
    }
}