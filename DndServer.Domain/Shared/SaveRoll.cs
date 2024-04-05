using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Shared;

public class SaveRoll
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public SkillTypesEnum Skill { get; set; }

    public SaveRoll(int id, int characterId, SkillTypesEnum skill)
    {
        Id = id;
        CharacterId = characterId;
        Skill = skill;
    }
}