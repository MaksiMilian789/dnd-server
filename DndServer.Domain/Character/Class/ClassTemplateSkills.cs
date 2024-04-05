namespace DndServer.Domain.Character.Class;

public class ClassTemplateSkills
{
    public int Id { get; set; }
    public int ClassTemplateId { get; set; }
    public int SkillId { get; set; }

    public ClassTemplateSkills(int id, int classTemplateId, int skillId)
    {
        Id = id;
        ClassTemplateId = classTemplateId;
        SkillId = skillId;
    }
}