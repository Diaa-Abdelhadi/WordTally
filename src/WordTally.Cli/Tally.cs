namespace WordTally.Cli;

public readonly record struct TallyResult(int Lines, int Words, int Characters);

public static class Tally
{
    public static TallyResult Count(string text)
    {
        var lines = text.Length == 0 ? 0 : text.Split('\n').Length;
        var words = text.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries).Length;
        var characters = text.Length;

        return new TallyResult(lines, words, characters);
    }
}
