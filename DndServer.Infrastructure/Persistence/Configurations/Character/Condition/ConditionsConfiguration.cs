using DndServer.Domain.Character.Condition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Character.Condition;

public class ConditionsConfiguration : IEntityTypeConfiguration<Conditions>
{
    public void Configure(EntityTypeBuilder<Conditions> builder) =>
        builder.HasKey(x => x.Id);
}