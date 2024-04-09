using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.User;

public class UserConfiguration : IEntityTypeConfiguration<Domain.User.User>
{
    public void Configure(EntityTypeBuilder<Domain.User.User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Login).IsUnique();
        builder.HasMany(x => x.WorldLinks).WithOne(x => x.User);
    }
}