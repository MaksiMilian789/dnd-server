using DndServer.Application.Worlds.Models;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Application.Worlds.Interfaces;

public interface IWorldService
{
    public Task<List<ShortWorldDto>> GetWorlds(int userId, RoleEnum? role);
    public Task<WorldDto> GetWorld(int worldId);
    public Task CreateWorld(WorldCreateDto dto, int userId);
    public Task EditWorld(WorldDto dto);
    public Task AddWikiPart(string name, int worldId);
    public Task SaveWikiPage(string header, string text, int? imageId, int? pageId, int wikiId);
    public Task<List<UserRoleDto>> GetUserRoles(int worldId);
    public Task SetUserRoles(int worldId, List<UserRoleDto> userRoles);
}