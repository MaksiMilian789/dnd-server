﻿using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Application.Characters.Models.Instances;

public class SkillInstanceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public ActionTypesEnum ActionType { get; set; }
    public SkillTypesEnum SkillType { get; set; }
    public SkillValue Value { get; set; } = null!;
    public ActionTime ActionTime { get; set; } = null!;
    public int? Distance { get; set; }
    public bool Passive { get; set; }
    public bool Activated { get; set; }
    public RechargeEnum Recharge { get; set; }
    public int Charges { get; set; }
    public int CurrentCharges { get; set; }
    public SystemEnum System { get; set; }
}