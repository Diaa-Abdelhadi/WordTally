using WordTally.Cli;
using Xunit;

namespace WordTally.Tests;

public class TallyTests
{
    [Fact]
    public void Empty_text_counts_zero()
    {
        var result = Tally.Count("");

        Assert.Equal(0, result.Lines);
        Assert.Equal(0, result.Words);
        Assert.Equal(0, result.Characters);
    }

    [Fact]
    public void Single_line_counts_one_line()
    {
        var result = Tally.Count("hello world");

        Assert.Equal(1, result.Lines);
        Assert.Equal(2, result.Words);
        Assert.Equal(11, result.Characters);
    }

    [Fact]
    public void Counts_lines_by_newline()
    {
        var result = Tally.Count("one\ntwo\nthree\n");

        Assert.Equal(4, result.Lines);
        Assert.Equal(3, result.Words);
    }

    [Fact]
    public void Collapses_repeated_whitespace_between_words()
    {
        var result = Tally.Count("one   two\tthree");

        Assert.Equal(3, result.Words);
    }
}
