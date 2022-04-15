using WpfCodeGenerator.Core.Models;

namespace WpfCodeGenerator.Core.ViewModels;

public class GeneratorViewModel
{
    public GeneratorViewModel(string json, string className, string language)
    {
        var parameters = new Parameters(json, className, language);
        parameters.Validate();
    }
}