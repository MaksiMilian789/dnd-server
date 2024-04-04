namespace DndServer.Domain.User;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }

    public User(int id, string login, string passwordHash)
    {
        Id = id;
        Login = login;
        PasswordHash = passwordHash;
    }
}