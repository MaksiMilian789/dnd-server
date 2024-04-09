﻿using DndServer.Domain.Character.Skill;
using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Character.Spell;

public class SpellInstance
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Level { get; set; }
    public int Distance { get; set; }
    public ActionTypesEnum ActionType { get; set; }
    public Damage Damage { get; set; }
    public ActionTime ActionTime { get; set; }
    public List<SpellComponents> Components { get; set; }
    public SystemEnum System { get; set; }
    public ICollection<SkillInstance> SkillInstance { get; set; }
    public ICollection<Character> Character { get; set; }

    public SpellInstance(int id, string name, string description, int level, int distance, ActionTypesEnum actionType,
        Damage damage, ActionTime actionTime, List<SpellComponents> components, SystemEnum system)
    {
        Id = id;
        Name = name;
        Description = description;
        Level = level;
        Distance = distance;
        ActionType = actionType;
        Damage = damage;
        ActionTime = actionTime;
        Components = components;
        System = system;
        SkillInstance = new List<SkillInstance>();
        Character = new List<Character>();
    }
}