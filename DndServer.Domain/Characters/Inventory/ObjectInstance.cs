﻿using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Inventory;

public class ObjectInstance
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
    public bool Equipped { get; set; }
    public int? Distance { get; set; }
    public int Quantity { get; set; }
    public int? ImageId { get; set; }
    public virtual Image? Image { get; set; }
    public SystemEnum System { get; set; }
    public virtual ICollection<SkillInstance> SkillInstance { get; set; }
    public virtual ICollection<Character> Character { get; set; }

    public ObjectInstance(string name, string description, AttackTypesEnum attackType, bool attachment,
        RareEnum rare, ItemTypeEnum type, CharacteristicsEnum mainCharacteristic, bool equipped, int? distance,
        int quantity, int? imageId, SystemEnum system)
    {
        Name = name;
        Description = description;
        AttackType = attackType;
        Attachment = attachment;
        Rare = rare;
        Type = type;
        MainCharacteristic = mainCharacteristic;
        Equipped = equipped;
        Distance = distance;
        Quantity = quantity;
        ImageId = imageId;
        System = system;
        SkillInstance = new List<SkillInstance>();
        Character = new List<Character>();
    }
}