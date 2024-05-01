using DndServer.Domain.Characters.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters.Class;

public class ClassInstanceConfiguration : IEntityTypeConfiguration<ClassInstance>
{
    public void Configure(EntityTypeBuilder<ClassInstance> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Character).WithOne(x => x.ClassInstance).HasForeignKey(x => x.ClassInstanceId);
    }
}