namespace DndServer.Domain.Character.Condition;

public class Conditions
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Conditions(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}