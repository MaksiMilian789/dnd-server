using DndServer.Domain.Shared;

namespace DndServer.Domain.Worlds;

public class WikiPage
{
    public int Id { get; set; }
    public virtual Wiki Wiki { get; set; } = null!;
    public string Header { get; set; }
    public string Text { get; set; }
    public int ImageId { get; set; }
    public virtual Image Image { get; set; } = null!;

    public WikiPage(string header, string text)
    {
        Header = header;
        Text = text;
    }
}