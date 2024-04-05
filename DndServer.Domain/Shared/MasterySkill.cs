using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Shared;

public class MasterySkill
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public SkillTypesEnum Skill { get; set; }
    public bool Competent { get; set; }

    public MasterySkill(int id, int characterId, SkillTypesEnum skill, bool competent)
    {
        Id = id;
        CharacterId = characterId;
        Skill = skill;
        Competent = competent;
    }
}