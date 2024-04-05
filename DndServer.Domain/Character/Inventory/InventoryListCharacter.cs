namespace DndServer.Domain.Character.Inventory;

public class InventoryListCharacter
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public int ObjectId { get; set; }
    public int Quantity { get; set; }

    public InventoryListCharacter(int id, int characterId, int objectId, int quantity)
    {
        Id = id;
        CharacterId = characterId;
        ObjectId = objectId;
        Quantity = quantity;
    }
}