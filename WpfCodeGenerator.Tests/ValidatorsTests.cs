using WpfCodeGenerator.Core.Validators;
using Xunit;

namespace WpfCodeGenerator.Tests;

public class ValidatorTests
{
    [Fact]
    public void ValidClassName()
    {
        var classNameValidator = new ClassNameValidator("test.bonjour");
        Assert.Equal("", classNameValidator.Error);
    }

    [Fact]
    public void InvalidClassName()
    {
        var classNameValidator = new ClassNameValidator("test");
        Assert.NotEqual("", classNameValidator.Error);
    }

    [Fact]
    public void ValidJson()
    {
        var jsonValidator = new JsonValidator(
            "{\n  \"languages\": [\n    {\n      \"language\": \"English\",\n      \"image\": \"imagePath\",\n      \"jsonPath\": \"jsonPath\"\n    },\n    {\n      \"language\": \"Français\",\n      \"image\": \"imagePath\",\n      \"jsonPath\": \"jsonPath\"\n    },\n    {\n      \"language\": \"Español\",\n      \"image\": \"imagePath\",\n      \"jsonPath\": \"jsonPath\"\n    }\n  ]\n}");
        Assert.Equal("", jsonValidator.Error);
    }

    [Fact]
    public void InvalidJson()
    {
        var jsonValidator = new JsonValidator("invalid json");
        Assert.NotEqual("", jsonValidator.Error);
    }
}