namespace DndServer.Domain.Characters.Condition;

public class Conditions
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Character> Character { get; set; }

    public Conditions(string name, string description)
    {
        Name = name;
        Description = description;
        Character = new List<Character>();
    }
}