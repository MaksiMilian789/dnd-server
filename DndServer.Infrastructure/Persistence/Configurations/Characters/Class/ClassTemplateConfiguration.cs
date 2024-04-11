using DndServer.Domain.Characters.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters.Class;

public class ClassTemplateConfiguration : IEntityTypeConfiguration<ClassTemplate>
{
    public void Configure(EntityTypeBuilder<ClassTemplate> builder)
    {
    }
}