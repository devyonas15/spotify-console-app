using System.Net.Http.Headers;
using System.Text.Json;
using SpotifyConsoleApp.Constants;
using SpotifyConsoleApp.DTOs.Artist;
using SpotifyConsoleApp.Model;

namespace SpotifyConsoleApp.Services;

public sealed class ArtistService
{
    private const string ArtistUri = "/artists";

    /// <summary>
    /// Get artist details based on ID
    /// </summary>
    /// <param name="client">HTTP client</param>
    /// <param name="apiKey">API Key to interract with the Spotify API</param>
    /// <param name="id">Artist ID</param>
    /// <returns>Auth response, containing access token and lifetime</returns>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="JsonException"></exception>
    public async Task<ArtistResponse?> GetArtistDetailsAsync(HttpClient client, string id, string apiKey)
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        
        var httpResult = await client.GetAsync($"{Url.BaseApiUrl}{ArtistUri}/{id}");
        httpResult.EnsureSuccessStatusCode();

        var jsonData = await httpResult.Content.ReadAsStringAsync();
        var artistDetails = JsonSerializer.Deserialize<Artist>(jsonData);

        if (artistDetails is null)
        {
            return null;
        }

        return new ArtistResponse
        {
            Name = artistDetails.Name,
            Popularity = artistDetails.Popularity,
            ArtistImage = artistDetails.Images[0].Url,
            ArtistSpotifyLink = artistDetails.ExternalUrls.Spotify
        };
    }
}