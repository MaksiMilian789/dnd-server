using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.World;

public class WorldLinks
{
    public int Id { get; set; }
    public User.User User { get; set; } = null!;
    public World World { get; set; } = null!;
    public RoleEnum Role { get; set; }

    public WorldLinks(int id, RoleEnum role)
    {
        Id = id;
        Role = role;
    }
}