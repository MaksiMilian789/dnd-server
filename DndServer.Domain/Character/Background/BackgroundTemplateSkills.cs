namespace DndServer.Domain.Character.Background;

public class BackgroundTemplateSkills
{
    public int Id { get; set; }
    public int BackgroundTemplateId { get; set; }
    public int SkillId { get; set; }

    public BackgroundTemplateSkills(int id, int backgroundTemplateId, int skillId)
    {
        Id = id;
        BackgroundTemplateId = backgroundTemplateId;
        SkillId = skillId;
    }
}