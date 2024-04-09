namespace DndServer.Domain.World;

public class WikiPage
{
    public int Id { get; set; }
    public Wiki Wiki { get; set; }
    public string Header { get; set; }
    public string Text { get; set; }

    public WikiPage(int id, Wiki wiki, string header, string text)
    {
        Id = id;
        Wiki = wiki;
        Header = header;
        Text = text;
    }
}