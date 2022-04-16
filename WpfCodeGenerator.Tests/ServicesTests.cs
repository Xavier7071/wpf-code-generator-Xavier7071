using WpfCodeGenerator.Core.Services;
using Xunit;

namespace WpfCodeGenerator.Tests;

public class ServicesTests
{
    [Fact]
    public void ValidNames()
    {
        var list = new List<string>
        {
            "salut.test",
            "bonjour"
        };
        Assert.Equal(list, GeneratorService.GetNames("salut.test.bonjour"));
    }

    [Fact]
    public void InvalidNames()
    {
        var list = new List<string>
        {
            "salut.test.",
            "bonjour"
        };
        Assert.NotEqual(list, GeneratorService.GetNames("salut.test.bonjour"));
    }
}