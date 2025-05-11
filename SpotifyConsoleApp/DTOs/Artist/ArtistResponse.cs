using System.Text.Json.Serialization;

namespace SpotifyConsoleApp.DTOs.Artist;

public sealed class ArtistResponse
{
    [JsonPropertyName("artist_name")] 
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("artist_popularity")]
    public int Popularity { get; set; }

    [JsonPropertyName("artist_image")] 
    public string? ArtistImage { get; set; }

    [JsonPropertyName("artist_spotify_link")]
    public string ArtistSpotifyLink { get; set; } = string.Empty;
}