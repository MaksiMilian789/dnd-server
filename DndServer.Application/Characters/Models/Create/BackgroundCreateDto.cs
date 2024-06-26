﻿using DndServer.Domain.Shared.Enums;

namespace DndServer.Application.Characters.Models.Create;

public class BackgroundCreateDto
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public SystemEnum System { get; set; }
    public int AuthorId { get; set; }
    public List<int> SkillIds { get; set; } = new();
    public int? WorldId { get; set; }
}