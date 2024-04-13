using DndServer.Domain.Characters.Background;
using DndServer.Domain.Characters.Class;
using DndServer.Domain.Characters.Inventory;
using DndServer.Domain.Characters.Race;
using DndServer.Domain.Characters.Spell;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Skill;

public class SkillTemplate : SkillInstance
{
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }
    public ICollection<BackgroundTemplate> BackgroundTemplate { get; set; }
    public ICollection<ClassTemplate> ClassTemplate { get; set; }
    public ICollection<ObjectTemplate> ObjectTemplate { get; set; }
    public ICollection<RaceTemplate> RaceTemplate { get; set; }
    public ICollection<SpellTemplate> SpellTemplate { get; set; }

    public SkillTemplate(string name, string description, ActionTypesEnum actionType, SkillTypesEnum skillType,
        int? distance, bool passive, int recharge, int charges, SystemEnum system, int authorId,
        int? worldId) : base(name, description, actionType, skillType, distance, passive, recharge, charges, system)
    {
        AuthorId = authorId;
        WorldId = worldId;
        BackgroundTemplate = new List<BackgroundTemplate>();
        ClassTemplate = new List<ClassTemplate>();
        ObjectTemplate = new List<ObjectTemplate>();
        RaceTemplate = new List<RaceTemplate>();
        SpellTemplate = new List<SpellTemplate>();
    }
}