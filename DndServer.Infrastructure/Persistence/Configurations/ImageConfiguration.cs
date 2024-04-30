using DndServer.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Note).WithOne(x => x.Image).HasForeignKey(x => x.ImageId);
        builder.HasMany(x => x.WikiPage).WithOne(x => x.Image).HasForeignKey(x => x.ImageId);
        builder.HasMany(x => x.World).WithOne(x => x.Image).HasForeignKey(x => x.ImageId);
        builder.HasMany(x => x.ObjectInstance).WithOne(x => x.Image).HasForeignKey(x => x.ImageId);
        builder.HasMany(x => x.ObjectTemplate).WithOne(x => x.Image).HasForeignKey(x => x.ImageId);
        builder.HasMany(x => x.Character).WithOne(x => x.Image).HasForeignKey(x => x.ImageId);
    }
}