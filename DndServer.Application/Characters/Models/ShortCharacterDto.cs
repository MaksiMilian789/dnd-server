using DndServer.Domain.Shared.Enums;

namespace DndServer.Application.Characters.Models;

public class ShortCharacterDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string ClassName { get; set; } = "";
    public int Level { get; set; }
    public SystemEnum System { get; set; }
}