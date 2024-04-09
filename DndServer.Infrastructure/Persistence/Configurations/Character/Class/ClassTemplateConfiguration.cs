using DndServer.Domain.Character.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Character.Class;

public class ClassTemplateConfiguration : IEntityTypeConfiguration<ClassTemplate>
{
    public void Configure(EntityTypeBuilder<ClassTemplate> builder)
    {
    }
}