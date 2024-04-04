namespace DndServer.Domain.World;

public class WikiPage
{
    public int Id { get; set; }
    public int WikiSectionId { get; set; }
    public string Header { get; set; }
    public string Text { get; set; }

    public WikiPage(int id, int wikiSectionId, string header, string text)
    {
        Id = id;
        WikiSectionId = wikiSectionId;
        Header = header;
        Text = text;
    }
}