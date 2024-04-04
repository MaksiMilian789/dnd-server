using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Shared;

public class DiceRolls
{
    public int Rolls { get; set; }
    public DiceEnum Dice { get; set; }

    public DiceRolls(int rolls, DiceEnum dice)
    {
        Rolls = rolls;
        Dice = dice;
    }
}