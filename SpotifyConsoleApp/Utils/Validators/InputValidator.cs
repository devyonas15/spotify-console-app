using System.Text.Json;

namespace SpotifyConsoleApp.Utils.Validators;

public static class InputValidator
{
    public static bool IsValidJson(string jsonToTest)
    {
        try
        {
            var json = JsonSerializer.Deserialize<object>(jsonToTest);

            return true;
        }
        catch
        {
            return false;
        }
    }
}