using DndServer.Domain.Characters;
using DndServer.Domain.Characters.Inventory;
using DndServer.Domain.Characters.Notes;
using DndServer.Domain.Worlds;

namespace DndServer.Domain.Shared;

public class Image
{
    public int Id { get; set; }
    public string Path { get; set; }
    public byte[] ImageByte { get; set; }
    public virtual ICollection<Character> Character { get; set; } = null!;
    public virtual ICollection<World> World { get; set; } = null!;
    public virtual ICollection<Note> Note { get; set; } = null!;
    public virtual ICollection<WikiPage> WikiPage { get; set; } = null!;
    public virtual ICollection<ObjectTemplate> ObjectTemplate { get; set; } = null!;
    public virtual ICollection<ObjectInstance> ObjectInstance { get; set; } = null!;
    public bool Deleted { get; set; }

    public Image(string path, byte[] imageByte)
    {
        Path = path;
        ImageByte = imageByte;
    }
}