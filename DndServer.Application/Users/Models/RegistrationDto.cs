namespace DndServer.Application.Users.Models;

public class RegistrationDto
{
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
}