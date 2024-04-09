﻿namespace DndServer.Domain.World;

public class Tracker
{
    public int Id { get; set; }
    public World World { get; set; }
    public string Name { get; set; }
    public double Initiative { get; set; }
    public string? Color { get; set; }
    public string? Icon { get; set; }

    public Tracker(int id, World world, string name, double initiative, string? color, string? icon)
    {
        Id = id;
        World = world;
        Name = name;
        Initiative = initiative;
        Color = color;
        Icon = icon;
    }
}