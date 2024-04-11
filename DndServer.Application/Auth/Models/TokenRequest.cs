using Microsoft.AspNetCore.Mvc;

namespace DndServer.Application.Auth.Models;

public class TokenRequest
{
    [FromForm(Name = "grant_type")] public string GrantType { get; set; } = "";

    [FromForm(Name = "login")] public string? Login { get; set; }

    [FromForm(Name = "password")] public string? Password { get; set; }
}