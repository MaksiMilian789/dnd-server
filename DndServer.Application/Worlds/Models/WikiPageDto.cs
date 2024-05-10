namespace DndServer.Application.Worlds.Models;

public class WikiPageDto
{
    public int Id { get; set; }
    public string Header { get; set; } = "";
    public string Text { get; set; } = "";
    public int? ImageId { get; set; }
}