using WpfCodeGenerator.Core.Models;

namespace WpfCodeGenerator.Core.ViewModels;

public class GeneratorViewModel
{
    public List<string> ErrorMessages { get; }
    
    public GeneratorViewModel(string json, string className, string language)
    {
        var parameters = new Parameters(json, className, language);
        ErrorMessages = parameters.Validate();
    }
}