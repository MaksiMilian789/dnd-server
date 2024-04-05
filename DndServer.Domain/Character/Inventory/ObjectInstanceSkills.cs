namespace DndServer.Domain.Character.Inventory;

public class ObjectInstanceSkills
{
    public int Id { get; set; }
    public int ObjectInstanceId { get; set; }
    public int SkillId { get; set; }

    public ObjectInstanceSkills(int id, int objectInstanceId, int skillId)
    {
        Id = id;
        ObjectInstanceId = objectInstanceId;
        SkillId = skillId;
    }
}