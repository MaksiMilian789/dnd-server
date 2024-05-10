using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Inventory;

public class ObjectTemplate
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Deleted { get; set; }
    public Damage Damage { get; set; } = null!;
    public AttackTypesEnum AttackType { get; set; }
    public bool Attachment { get; set; }
    public RareEnum Rare { get; set; }
    public ItemTypeEnum Type { get; set; }
    public CharacteristicsEnum MainCharacteristic { get; set; }
    public int? Distance { get; set; }
    public int? ImageId { get; set; }
    public virtual Image? Image { get; set; }
    public SystemEnum System { get; set; }
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }
    public virtual ICollection<SkillTemplate> SkillTemplate { get; set; }

    public ObjectTemplate(string name, string description, AttackTypesEnum attackType, bool attachment,
        RareEnum rare, ItemTypeEnum type, CharacteristicsEnum mainCharacteristic, int? distance, int? imageId,
        SystemEnum system, int authorId, int? worldId)
    {
        Name = name;
        Description = description;
        AttackType = attackType;
        Attachment = attachment;
        Rare = rare;
        Type = type;
        MainCharacteristic = mainCharacteristic;
        Distance = distance;
        ImageId = imageId;
        System = system;
        AuthorId = authorId;
        WorldId = worldId;
        SkillTemplate = new List<SkillTemplate>();
    }
}