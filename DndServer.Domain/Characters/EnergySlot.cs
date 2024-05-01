namespace DndServer.Domain.Characters;

public class EnergySlot
{
    public string Name { get; set; } = "";
    public int MaxQuantity { get; set; }
    public int CurrentQuantity { get; set; }
}