using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.World;

public class WorldLinks
{
    public int Id { get; set; }
    public User.User User { get; set; }
    public World World { get; set; }
    public RoleEnum Role { get; set; }

    public WorldLinks(int id, User.User user, World world, RoleEnum role)
    {
        Id = id;
        User = user;
        World = world;
        Role = role;
    }
}