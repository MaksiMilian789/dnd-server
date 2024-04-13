﻿using DndServer.Application.Characters.Models;

namespace DndServer.Application.Characters.Interfaces;

public interface IRaceService
{
    public Task<List<RaceDto>> GetRaces(string login);
}