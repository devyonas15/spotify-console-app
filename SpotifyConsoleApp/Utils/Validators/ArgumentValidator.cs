using SpotifyConsoleApp.Constants;

namespace SpotifyConsoleApp.Utils.Validators;

public static class ArgumentValidator
{
    public static bool IsValidMethod(string arg)
    {
        if (arg != ProgramType.Auth)
        {
            return false;
        }

        return true;
    }

    public static bool IsValidInputBasedOnMethod(string arg1, string arg2)
    {
        if (arg1 == ProgramType.Auth)
        {
            return InputValidator.IsValidJson(arg2);
        }

        return false;
    }
}