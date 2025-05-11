using System.Text.Json.Serialization;

namespace SpotifyConsoleApp.DTOs.Auth;

public sealed class AuthResponse
{
    /// <summary>
    /// Access Token to authenticate with Spotify API
    /// </summary>
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// Type of the access token
    /// </summary>
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; } = string.Empty;

    /// <summary>
    /// Token expiry in seconds
    /// </summary>
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }
}