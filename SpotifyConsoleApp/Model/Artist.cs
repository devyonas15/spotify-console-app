using System.Text.Json.Serialization;

namespace SpotifyConsoleApp.Model;

public sealed class ExternalUrl
{
    /// <summary>
    /// Spotify URL for the object
    /// </summary>
    [JsonPropertyName("spotify")]
    public string Spotify { get; set; } = string.Empty;
}

public sealed class Follower
{
    /// <summary>
    /// Link of the followers, currently should be null
    /// </summary>
    [JsonPropertyName("href")]
    public string? Href { get; set; }

    /// <summary>
    /// Total number of followers
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }
}

public sealed class Image
{
    /// <summary>
    /// Source URL of the artist image
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Image height in pixels
    /// </summary>
    [JsonPropertyName("height")]
    public int? Height { get; set; }

    /// <summary>
    /// Image width in pixels
    /// </summary>
    [JsonPropertyName("width")]
    public int? Width { get; set; }
}

public sealed class Artist
{
    /// <summary>
    /// External URLs related to the artist
    /// </summary>
    [JsonPropertyName("external_urls")]
    public ExternalUrl ExternalUrls { get; set; }

    /// <summary>
    /// Followers data for the artist
    /// </summary>
    [JsonPropertyName("followers")]
    public Follower Followers { get; set; }

    /// <summary>
    /// List of genres that are associated with the artist
    /// </summary>
    [JsonPropertyName("genres")]
    public string[] Genres { get; set; }

    /// <summary>
    /// Web API endpoint for the artist
    /// </summary>
    [JsonPropertyName("href")]
    public string Href { get; set; } = string.Empty;

    /// <summary>
    /// Artist's image
    /// </summary>
    [JsonPropertyName("images")]
    public Image[] Images { get; set; }

    /// <summary>
    /// Artist id
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Artist name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Artist popularity ranging from 0-100
    /// </summary>
    [JsonPropertyName("popularity")]
    public int Popularity { get; set; }

    /// <summary>
    /// Type of the data (artist)
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
}