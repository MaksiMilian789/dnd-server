using DndServer.Domain.Character.Background;
using DndServer.Domain.Character.Class;
using DndServer.Domain.Character.Inventory;
using DndServer.Domain.Character.Race;
using DndServer.Domain.Character.Spell;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Character.Skill;

public class SkillTemplate : SkillInstance
{
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }
    public ICollection<BackgroundTemplate> BackgroundTemplate { get; set; }
    public ICollection<ClassTemplate> ClassTemplate { get; set; }
    public ICollection<ObjectTemplate> ObjectTemplate { get; set; }
    public ICollection<RaceTemplate> RaceTemplate { get; set; }
    public ICollection<SpellTemplate> SpellTemplate { get; set; }

    public SkillTemplate(int id, string name, string description, ActionTypesEnum actionType, SkillTypesEnum skillType,
        SkillValue value, int? distance, bool passive, int recharge, int charges, SystemEnum system, int authorId,
        int? worldId) : base(id, name,
        description, actionType, skillType, value, distance, passive, recharge, charges, system)
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