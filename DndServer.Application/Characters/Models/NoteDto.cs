namespace DndServer.Application.Characters.Models;

public class NoteDto
{
    public int Id { get; set; }
    public string Header { get; set; } = "";
    public string Text { get; set; } = "";
    public int? ImageId { get; set; }
}