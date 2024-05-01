using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Application.Characters.Models.Create;

public class ObjectCreateDto
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public Damage Damage { get; set; } = null!;
    public AttackTypesEnum AttackType { get; set; }
    public bool Attachment { get; set; }
    public RareEnum Rare { get; set; }
    public ItemTypeEnum Type { get; set; }
    public CharacteristicsEnum MainCharacteristic { get; set; }
    public bool Equipped { get; set; }
    public int Quantity { get; set; }
    public int? ImageId { get; set; }
    public int? Distance { get; set; }
    public SystemEnum System { get; set; }
    public int AuthorId { get; set; }
    public List<int> SkillIds { get; set; } = new();
    public int? WorldId { get; set; }
}