namespace DndServer.Domain.Shared;

public class Effect
{
    public int Flat { get; set; }
    public int Dynamic { get; set; }
    public bool Advantage { get; set; }
    public bool DisAdvantage { get; set; }
    public bool Mastery { get; set; }
    public bool Competent { get; set; }
    public bool SaveRoll { get; set; }

    public Effect(int flat, int dynamic, bool advantage, bool disAdvantage, bool mastery, bool competent, bool saveRoll)
    {
        Flat = flat;
        Dynamic = dynamic;
        Advantage = advantage;
        DisAdvantage = disAdvantage;
        Mastery = mastery;
        Competent = competent;
        SaveRoll = saveRoll;
    }
}