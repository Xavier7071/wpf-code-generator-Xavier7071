using WpfCodeGenerator.Core.Models;

namespace WpfCodeGenerator.Core.ViewModels;

public class GeneratorViewModel
{
    public List<string> ErrorMessages { get; }
    public string ConvertedJson { get; }

    public GeneratorViewModel(string json, string className, string language)
    {
        var parameters = new Parameters(json, className, language);
        ErrorMessages = parameters.Validate();
        ConvertedJson = "";

        if (ErrorMessages[0].Length == 0 && ErrorMessages[1].Length == 0)
        {
            ConvertedJson = parameters.Convert();
        }
    }
}