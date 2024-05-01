namespace DndServer.Domain.Characters.Spell;

public class SpellSlot
{
    public int Level { get; set; }
    public int MaxQuantity { get; set; }
    public int CurrentQuantity { get; set; }
}