namespace DndServer.Domain.Character.Background;

public class BackgroundInstanceSkills
{
    public int Id { get; set; }
    public int BackgroundInstanceId { get; set; }
    public int SkillId { get; set; }

    public BackgroundInstanceSkills(int id, int backgroundInstanceId, int skillId)
    {
        Id = id;
        BackgroundInstanceId = backgroundInstanceId;
        SkillId = skillId;
    }
}