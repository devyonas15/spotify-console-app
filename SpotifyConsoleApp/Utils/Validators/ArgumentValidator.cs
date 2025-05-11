using SpotifyConsoleApp.Constants;

namespace SpotifyConsoleApp.Utils.Validators;

public static class ArgumentValidator
{
    public static bool IsValidMethod(string arg)
    {
        return arg is ProgramType.Auth or ProgramType.ArtistDetails;
    }

    public static bool IsValidInputBasedOnMethod(string arg1, string arg2)
    {
        switch (arg1)
        {
            case ProgramType.Auth:
                return InputValidator.IsValidJson(arg2);
            case ProgramType.ArtistDetails:
                return !string.IsNullOrEmpty(arg2);
            default:
                return false;
        }
    }
}