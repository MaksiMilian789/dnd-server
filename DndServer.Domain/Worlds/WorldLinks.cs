using DndServer.Domain.Shared.Enums;
using DndServer.Domain.Users;

namespace DndServer.Domain.Worlds;

public class WorldLinks
{
    public int Id { get; set; }
    public User User { get; set; } = null!;
    public World World { get; set; } = null!;
    public RoleEnum Role { get; set; }

    public WorldLinks(RoleEnum role)
    {
        Role = role;
    }
}