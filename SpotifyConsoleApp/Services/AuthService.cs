using System.Text.Json;
using SpotifyConsoleApp.Constants;
using SpotifyConsoleApp.DTOs.Auth;

namespace SpotifyConsoleApp.Services;

public sealed class AuthService
{
    /// <summary>
    /// Authenticate with Spotify and get the access token to access API
    /// </summary>
    /// <param name="httpClient">Http client</param>
    /// <param name="request">Auth request from Spotify Developers</param>
    /// <returns>Auth response, containing access token and lifetime</returns>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="JsonException"></exception>
    public async Task<AuthResponse?> AuthenticateAsync(HttpClient httpClient, AuthRequest request)
    {
        var requestDict = new Dictionary<string, string>
        {
            { "client_id", request.ClientId },
            { "client_secret", request.ClientSecret },
            { "grant_type", request.GrantType }
        };

        var httpResult = await httpClient.PostAsync($"{Url.BaseAuthUrl}", new FormUrlEncodedContent(requestDict));

        httpResult.EnsureSuccessStatusCode();

        var jsonData = await httpResult.Content.ReadAsStringAsync();

        var response = JsonSerializer.Deserialize<AuthResponse>(jsonData);

        return response;
    }
}