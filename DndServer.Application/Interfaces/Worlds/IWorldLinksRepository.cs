using DndServer.Domain.Worlds;

namespace DndServer.Application.Interfaces.Worlds;

public interface IWorldLinksRepository : IGenericRepository<WorldLinks>
{
    IEnumerable<WorldLinks> GetWithoutTracking();
}