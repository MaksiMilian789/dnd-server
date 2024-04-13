using System.Text.Json.Serialization;

namespace DndServer.Application.Auth.Models;

public class TokenResponse
{
    [JsonPropertyName("access_token")] public string AccessToken { get; set; } = null!;
}