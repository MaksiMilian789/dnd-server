using DndServer.Domain.Characters;
using DndServer.Domain.Worlds;

namespace DndServer.Domain.Users;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public virtual ICollection<Character> Character { get; set; }
    public virtual ICollection<WorldLinks> WorldLinks { get; set; }

    public User(string login, string passwordHash)
    {
        Login = login;
        PasswordHash = passwordHash;
        Character = new List<Character>();
        WorldLinks = new List<WorldLinks>();
    }
}