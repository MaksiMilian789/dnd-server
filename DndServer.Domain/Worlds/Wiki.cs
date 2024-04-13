﻿namespace DndServer.Domain.Worlds;

public class Wiki
{
    public int Id { get; set; }
    public World World { get; set; } = null!;
    public string Name { get; set; }
    public ICollection<WikiPage> WikiPage { get; set; }

    public Wiki(string name)
    {
        Name = name;
        WikiPage = new List<WikiPage>();
    }
}