using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Character;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int Age { get; set; }
    public int Speed { get; set; }
    public int ClassId { get; set; }
    public int GenderId { get; set; }
    public int RaceId { get; set; }
    public int BackgroundId { get; set; }
    public int IdeologyId { get; set; }
    public Characteristics Characteristics { get; set; }
    public SystemEnum System { get; set; }

    public Character(int id, string name, int level, int age, int speed, int classId, int genderId, int raceId,
        int backgroundId, int ideologyId, Characteristics characteristics, SystemEnum system)
    {
        Id = id;
        Name = name;
        Level = level;
        Age = age;
        Speed = speed;
        ClassId = classId;
        GenderId = genderId;
        RaceId = raceId;
        BackgroundId = backgroundId;
        IdeologyId = ideologyId;
        Characteristics = characteristics;
        System = system;
    }
}