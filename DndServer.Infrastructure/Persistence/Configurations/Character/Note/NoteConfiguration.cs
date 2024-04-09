using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Character.Note;

public class NoteConfiguration : IEntityTypeConfiguration<Domain.Character.Note.Note>
{
    public void Configure(EntityTypeBuilder<Domain.Character.Note.Note> builder) =>
        builder.HasKey(x => x.Id);
}