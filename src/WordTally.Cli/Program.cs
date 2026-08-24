using WordTally.Cli;

if (args.Length == 0)
{
    Console.Error.WriteLine("usage: wordtally <file>...");
    return 1;
}

var totalLines = 0;
var totalWords = 0;
var totalCharacters = 0;

foreach (var path in args)
{
    if (!File.Exists(path))
    {
        Console.Error.WriteLine($"file not found: {path}");
        return 1;
    }

    var text = File.ReadAllText(path);
    var result = Tally.Count(text);

    totalLines += result.Lines;
    totalWords += result.Words;
    totalCharacters += result.Characters;

    Console.WriteLine($"{result.Lines,7} {result.Words,7} {result.Characters,7} {path}");
}

if (args.Length > 1)
{
    Console.WriteLine($"{totalLines,7} {totalWords,7} {totalCharacters,7} total");
}

return 0;
