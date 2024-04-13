using DndServer.Domain.Characters;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Application.Characters.Models;

public class CharacterCreateDto
{
    public string Name { get; set; } = "";
    public int Level { get; set; }
    public int Age { get; set; }
    public GenderEnum Gender { get; set; }
    public IdeologyEnum Ideology { get; set; }
    public int ClassId { get; set; }
    public int RaceId { get; set; }
    public int BackgroundId { get; set; }
    public SystemEnum System { get; set; }
    public Characteristics Characteristics { get; set; } = null!;
}