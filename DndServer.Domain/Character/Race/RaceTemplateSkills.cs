namespace DndServer.Domain.Character.Race;

public class RaceTemplateSkills
{
    public int Id { get; set; }
    public int RaceTemplateId { get; set; }
    public int SkillId { get; set; }

    public RaceTemplateSkills(int id, int raceTemplateId, int skillId)
    {
        Id = id;
        RaceTemplateId = raceTemplateId;
        SkillId = skillId;
    }
}