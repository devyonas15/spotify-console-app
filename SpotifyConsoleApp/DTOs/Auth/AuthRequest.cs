using System.Text.Json.Serialization;

namespace SpotifyConsoleApp.DTOs.Auth;

public sealed class AuthRequest
{
    /// <summary>
    /// Client Id from Spotify
    /// </summary>
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; } = string.Empty;

    /// <summary>
    /// Client Secret from Spotify
    /// </summary>
    [JsonPropertyName("client_secret")]
    public string ClientSecret { get; set; } = string.Empty;

    /// <summary>
    /// Grant type 
    /// </summary>
    [JsonPropertyName("grant_type")]
    public string GrantType { get; set; } = string.Empty;
}