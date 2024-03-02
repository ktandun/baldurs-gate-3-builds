namespace BG3Builds.Shared.Extensions;

public static class StringExtensions
{
    public static bool ToBool(this string input)
    {
        return input switch
        {
            "Yes" => true,
            "No" => false,
            _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
        };
    }
}