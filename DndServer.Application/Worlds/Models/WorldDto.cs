﻿namespace DndServer.Application.Worlds.Models;

public class WorldDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int TrackerId { get; set; }
    public int WikiId { get; set; }
}