using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Character.Background;

public class BackgroundInstance
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public SystemEnum System { get; set; }

    public BackgroundInstance(int id, string name, string description, SystemEnum system)
    {
        Id = id;
        Name = name;
        Description = description;
        System = system;
    }
}