namespace DndServer.Domain.Worlds;

public class WikiPage
{
    public int Id { get; set; }
    public Wiki Wiki { get; set; } = null!;
    public string Header { get; set; }
    public string Text { get; set; }

    public WikiPage(int id, string header, string text)
    {
        Id = id;
        Header = header;
        Text = text;
    }
}