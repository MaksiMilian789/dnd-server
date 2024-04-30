using DndServer.Domain.Shared;

namespace DndServer.Domain.Characters.Notes;

public class Note
{
    public int Id { get; set; }
    public string Header { get; set; }
    public string Text { get; set; }
    public int ImageId { get; set; }
    public virtual Image Image { get; set; } = null!;
    public virtual ICollection<Character> Character { get; set; }

    public Note(string header, string text)
    {
        Header = header;
        Text = text;
        Character = new List<Character>();
    }
}