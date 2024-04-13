﻿using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Class;

public class ClassTemplate : ClassInstance
{
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }
    public ICollection<SkillTemplate> SkillTemplate { get; set; }

    public ClassTemplate(string name, string description, SystemEnum system, int authorId, int? worldId) : base(name,
        description, system)
    {
        AuthorId = authorId;
        WorldId = worldId;
        SkillTemplate = new List<SkillTemplate>();
    }
}