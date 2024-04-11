using DndServer.Application.Interfaces.Characters.Notes;
using DndServer.Domain.Characters.Notes;

namespace DndServer.Infrastructure.Persistence.Repositories.Characters.Notes;

internal sealed class NoteRepository : GenericRepository<Note>, INoteRepository
{
    private readonly DataContext _context;

    public NoteRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}