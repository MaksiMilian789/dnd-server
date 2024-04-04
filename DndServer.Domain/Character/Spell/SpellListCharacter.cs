namespace DndServer.Domain.Character.Spell;

public class SpellListCharacter
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public int SpellId { get; set; }

    public SpellListCharacter(int id, int characterId, int spellId)
    {
        Id = id;
        CharacterId = characterId;
        SpellId = spellId;
    }
}