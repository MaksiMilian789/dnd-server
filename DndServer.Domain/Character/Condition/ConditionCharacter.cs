namespace DndServer.Domain.Character.Condition;

internal class ConditionCharacter
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public int ConditionId { get; set; }

    public ConditionCharacter(int id, int characterId, int conditionId)
    {
        Id = id;
        CharacterId = characterId;
        ConditionId = conditionId;
    }
}