namespace DndServer.Domain.Character.Class;

public class ClassInstanceSkills
{
    public int Id { get; set; }
    public int ClassInstanceId { get; set; }
    public int SkillId { get; set; }

    public ClassInstanceSkills(int id, int classInstanceId, int skillId)
    {
        Id = id;
        ClassInstanceId = classInstanceId;
        SkillId = skillId;
    }
}