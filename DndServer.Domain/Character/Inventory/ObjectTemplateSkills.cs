namespace DndServer.Domain.Character.Inventory;

public class ObjectTemplateSkills
{
    public int Id { get; set; }
    public int ObjectTemplateId { get; set; }
    public int SkillId { get; set; }

    public ObjectTemplateSkills(int id, int objectTemplateId, int skillId)
    {
        Id = id;
        ObjectTemplateId = objectTemplateId;
        SkillId = skillId;
    }
}