using DndServer.Domain.Shared.Enums;
using DndServer.Domain.Users;

namespace DndServer.Domain.Worlds;

public class WorldLinks
{
    public int Id { get; set; }
    public virtual User User { get; set; } = null!;
    public int UserId { get; set; }
    public virtual World World { get; set; } = null!;
    public int WorldId { get; set; }
    public RoleEnum Role { get; set; }

    public WorldLinks(RoleEnum role)
    {
        Role = role;
    }
}