using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Shared;

public class SpellComponents
{
    public List<string> Materials { get; set; }
    public ComponentsEnum Component { get; set; }

    public SpellComponents(List<string> materials, ComponentsEnum component)
    {
        Materials = materials;
        Component = component;
    }
}