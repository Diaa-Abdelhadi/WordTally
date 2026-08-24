using WordTally.Cli;

if (args.Length != 1)
{
    Console.Error.WriteLine("usage: wordtally <file>");
    return 1;
}

var path = args[0];
if (!File.Exists(path))
{
    Console.Error.WriteLine($"file not found: {path}");
    return 1;
}

var text = File.ReadAllText(path);
var result = Tally.Count(text);

Console.WriteLine($"{result.Lines,7} {result.Words,7} {result.Characters,7} {path}");
return 0;
