namespace DndServer.Domain.Worlds;

public class WikiPage
{
    public int Id { get; set; }
    public Wiki Wiki { get; set; } = null!;
    public string Header { get; set; }
    public string Text { get; set; }

    public WikiPage(string header, string text)
    {
        Header = header;
        Text = text;
    }
}