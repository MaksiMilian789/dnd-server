using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DndServer.Application.Auth.Interfaces;
using DndServer.Application.Auth.Models;
using DndServer.Application.Users.Interfaces;
using DndServer.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace DndServer.Application.Auth.Services;

public class JwtService : IJwtService
{
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IUserService _userService;

    public JwtService(
        IPasswordHasher<User> passwordHasher, IUserService userService)
    {
        _passwordHasher = passwordHasher;
        _userService = userService;
    }

    public async Task<TokenResponse> LogIn(TokenRequest tokenRequest)
    {
        if (tokenRequest.Login is null || tokenRequest.Password is null)
        {
            throw new UnauthorizedAccessException();
        }

        var user = await _userService.GetDomainUserByLogin(tokenRequest.Login);

        if (user is null)
        {
            throw new UnauthorizedAccessException();
        }

        var hashedPassword = _passwordHasher.HashPassword(user, tokenRequest.Password);

        if (hashedPassword != user.PasswordHash)
        {
            throw new UnauthorizedAccessException();
        }

        var accessToken = CreateJwt(user);

        return new TokenResponse
        {
            AccessToken = accessToken
        };
    }

    /// <summary>
    ///     Создает jwt токен
    /// </summary>
    /// <param name="user">Пользователь</param>
    /// <exception cref="ArgumentNullException"></exception>
    private string CreateJwt(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        // Create access token
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("d99b1b1486b9b46e9a1a68d555e499a20e8d78e39203f5e5febd99ed90b957d0");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(BuildClaims(user)),
            Expires = DateTime.UtcNow.AddMinutes(1440 * 7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var accessToken = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(accessToken);
    }

    /// <summary>
    ///     Создает набор Claims для пользователя
    /// </summary>
    /// <param name="user">Пользователь</param>
    /// <returns></returns>
    private IEnumerable<Claim> BuildClaims(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Login)
        };

        return claims;
    }
}