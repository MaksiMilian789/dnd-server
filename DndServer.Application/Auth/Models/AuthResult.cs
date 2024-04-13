namespace DndServer.Application.Auth.Models;

public class AuthResult
{
    public string AccessToken { get; }

    public AuthResult(string accessToken)
    {
        AccessToken = accessToken;
    }
}