namespace DndServer.Domain.Character.Note;

public class NoteLinks
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public int NoteId { get; set; }

    public NoteLinks(int id, int characterId, int noteId)
    {
        Id = id;
        CharacterId = characterId;
        NoteId = noteId;
    }
}