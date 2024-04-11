using DndServer.API.Resources;
using DndServer.Application.Auth.Interfaces;
using DndServer.Application.Auth.Models;
using DndServer.Application.Users.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DndServer.API.Controllers.Auth;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;

    public AuthController(
        IUserService userService,
        IJwtService jwtService)
    {
        _userService = userService;
        _jwtService = jwtService;
    }

    /// <summary>
    ///     Авторизует пользователя. При успешной авторизации возвращает JWT токен.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<AuthResult>> Authenticate(TokenRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Login) || string.IsNullOrWhiteSpace(request.Password))
            return Unauthorized(CreateFailResponse(Errors.AuthFailed));
        try
        {
            var token = await _jwtService.LogIn(request);
            return new AuthResult(token.AccessToken);
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized(CreateFailResponse(Errors.AuthFailed));
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    private static ProblemDetails CreateFailResponse(string title) => new() { Title = title };
}