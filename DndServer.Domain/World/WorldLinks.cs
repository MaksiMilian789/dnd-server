using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.World;

public class WorldLinks
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int WorldId { get; set; }
    public RoleEnum Role { get; set; }

    public WorldLinks(int id, int userId, int worldId, RoleEnum role)
    {
        Id = id;
        UserId = userId;
        WorldId = worldId;
        Role = role;
    }
}