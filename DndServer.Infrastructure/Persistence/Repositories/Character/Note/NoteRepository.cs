using DndServer.Application.Interfaces.Character.Note;

namespace DndServer.Infrastructure.Persistence.Repositories.Character.Note;

internal sealed class NoteRepository : GenericRepository<Domain.Character.Note.Note>, INoteRepository
{
    private readonly DataContext _context;

    public NoteRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}