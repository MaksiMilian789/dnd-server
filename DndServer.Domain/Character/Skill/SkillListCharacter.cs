namespace DndServer.Domain.Character.Skill;

internal class SkillListCharacter
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public int SkillId { get; set; }

    public SkillListCharacter(int id, int characterId, int skillId)
    {
        Id = id;
        CharacterId = characterId;
        SkillId = skillId;
    }
}