namespace DndServer.Application.Worlds.Models;

public class WikiDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public List<WikiPageDto> Pages { get; set; } = new();
}