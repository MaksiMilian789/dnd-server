using DndServer.Application.Auth.Models;

namespace DndServer.Application.Auth.Interfaces;

public interface IJwtService
{
    /// <summary>
    ///     Аутентификация.
    /// </summary>
    /// <param name="tokenRequest">Данные для аутентификации.</param>
    /// <returns></returns>
    public Task<TokenResponse> LogIn(TokenRequest tokenRequest);
}