// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using SpotifyConsoleApp.Constants;
using SpotifyConsoleApp.DTOs.Auth;
using SpotifyConsoleApp.Enums;
using SpotifyConsoleApp.Exceptions;
using SpotifyConsoleApp.Services;
using SpotifyConsoleApp.Utils.Validators;

var httpClient = new HttpClient();
var authService = new AuthService();
var artistService = new ArtistService();


if (args.Length < 2)
{
    throw new ArgumentException(
        "Minimum two arguments should be given. Example: dotnet run app -- [method_name] [input] [api_key]");
}

if (!ArgumentValidator.IsValidMethod(args[0]))
{
    throw new ArgumentException("Method must be a valid method. Available methods: auth, artist-details");
}

if (!ArgumentValidator.IsValidInputBasedOnMethod(args[0], args[1]))
{
    throw new ArgumentException(
        "Supplied input must be valid according to the given method. Please see the details in the README.");
}

try
{
    switch (args[0])
    {
        case ProgramType.Auth:
            var requestJson = JsonSerializer.Deserialize<AuthRequest>(args[1]);
            if (requestJson is not null)
            {
                var authenticateResult = await authService.AuthenticateAsync(httpClient, requestJson);
                Console.WriteLine(
                    $"Auth Successful. Access Token: {authenticateResult?.AccessToken}, Token Type: {authenticateResult?.TokenType}, Will be expired in {authenticateResult?.ExpiresIn} seconds");
            }

            break;
        case ProgramType.ArtistDetails:
            var artistResult = await artistService.GetArtistDetailsAsync(httpClient, args[1], args[2]);
            if (artistResult is null)
            {
                throw new NotFoundException($"Artist with Id {args[1]} cannot be found");
            }

            Console.WriteLine(
                $"Successfully Get Artist. Artist Name: {artistResult.Name}, Popularity: {artistResult.Popularity}, Image link: {artistResult.ArtistImage}, Spotify Link: {artistResult.ArtistSpotifyLink}");
            break;
        default:
            break;
    }
}
catch (Exception ex)
{
    switch (ex)
    {
        case ArgumentException:
            Console.WriteLine($"{ex.Message}");
            Environment.Exit((int)ExitCode.ArgumentException);
            break;
        case JsonException:
            Console.WriteLine("Valid JSON value as arguments should be supplied.");
            Environment.Exit((int)ExitCode.JsonException);
            break;
        case HttpRequestException:
            Console.WriteLine($"Failed to complete HTTP request. Reason: {ex.Message}");
            Environment.Exit((int)ExitCode.HttpRequestException);
            break;
        case NotFoundException:
            Console.WriteLine($"{ex.Message}");
            Environment.Exit((int)ExitCode.NotFoundException);
            break;
        default:
            Console.WriteLine($"Something went wrong when processing the app. Reason: {ex.Message}");
            Environment.Exit((int)ExitCode.UnknownSystemException);
            break;
    }
}