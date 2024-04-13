using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Shared;

public class DamageType
{
    public int Id { get; set; }
    public string Name { get; set; }
    public SystemEnum System { get; set; }

    public DamageType(int id, string name, SystemEnum system)
    {
        Id = id;
        Name = name;
        System = system;
    }
}