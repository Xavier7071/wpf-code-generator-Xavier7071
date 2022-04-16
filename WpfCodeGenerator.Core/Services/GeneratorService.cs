using System.Text.Json;
using CodeGenerator;

namespace WpfCodeGenerator.Core.Services;

public class GeneratorService
{
    public string ConvertedJson { get; }

    public GeneratorService(string json, string className, string language)
    {
        ConvertedJson = "";
        var parsedJson = ParseJson(json);
        var names = GetNames(className);
        LanguageGenerator generator = language switch
        {
            "CSharp" => new CSharpLanguageGenerator(parsedJson, names),
            "Swift" => new SwiftLanguageGenerator(parsedJson, names),
            _ => throw new ArgumentOutOfRangeException(nameof(language), language, null)
        };
        ConvertedJson = generator.StringBuilder.ToString();
    }

    private static JsonElement ParseJson(string json)
    {
        var doc = JsonDocument.Parse(json);
        return doc.RootElement;
    }

    private static List<string> GetNames(string className)
    {
        for (var i = className.Length - 1; i > 0; i--)
        {
            if (className[i].Equals('.'))
                return new List<string>
                {
                    className[..i], className[(i + 1)..]
                };
        }
        return null!;
    }
}