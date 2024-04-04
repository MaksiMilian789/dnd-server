namespace DndServer.Domain.Character;

public class CharacterLinks
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CharacterId { get; set; }

    public CharacterLinks(int id, int userId, int characterId)
    {
        Id = id;
        UserId = userId;
        CharacterId = characterId;
    }
}