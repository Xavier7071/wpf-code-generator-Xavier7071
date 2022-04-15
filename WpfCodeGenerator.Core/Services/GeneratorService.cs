namespace WpfCodeGenerator.Core.Services;

public class GeneratorService
{
    public string ConvertedJson { get; }
    
    public GeneratorService(string json, string className, string language)
    {
        ConvertedJson = "";
    }
}