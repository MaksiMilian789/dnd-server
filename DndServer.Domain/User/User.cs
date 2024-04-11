using DndServer.Domain.World;

namespace DndServer.Domain.User;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public ICollection<Character.Character> Character { get; set; }
    public ICollection<WorldLinks> WorldLinks { get; set; }

    public User(string login, string passwordHash)
    {
        Login = login;
        PasswordHash = passwordHash;
        Character = new List<Character.Character>();
        WorldLinks = new List<WorldLinks>();
    }
}