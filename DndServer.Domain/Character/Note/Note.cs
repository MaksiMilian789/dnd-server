namespace DndServer.Domain.Character.Note;

public class Note
{
    public int Id { get; set; }
    public string Header { get; set; }
    public string Text { get; set; }
    public ICollection<Character> Character { get; set; }

    public Note(int id, string header, string text)
    {
        Id = id;
        Header = header;
        Text = text;
        Character = new List<Character>();
    }
}