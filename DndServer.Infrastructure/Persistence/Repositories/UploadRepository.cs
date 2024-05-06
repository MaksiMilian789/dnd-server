using DndServer.Application.Interfaces.Upload;
using DndServer.Domain.Shared;

namespace DndServer.Infrastructure.Persistence.Repositories;

internal sealed class UploadRepository : GenericRepository<Image>, IUploadRepository
{
    private readonly DataContext _context;

    public UploadRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}