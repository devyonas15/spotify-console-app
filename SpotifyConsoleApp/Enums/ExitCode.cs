namespace SpotifyConsoleApp.Enums;

public enum ExitCode
{
    Success = 0,
    ArgumentException = 1,
    JsonException = 2,
    HttpRequestException = 3,
    UnknownSystemException = 50
}