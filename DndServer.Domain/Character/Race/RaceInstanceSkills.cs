namespace DndServer.Domain.Character.Race;

public class RaceInstanceSkills
{
    public int Id { get; set; }
    public int RaceInstanceId { get; set; }
    public int SkillId { get; set; }

    public RaceInstanceSkills(int id, int raceInstanceId, int skillId)
    {
        Id = id;
        RaceInstanceId = raceInstanceId;
        SkillId = skillId;
    }
}