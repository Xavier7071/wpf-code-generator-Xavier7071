using WpfCodeGenerator.Core.Validators;

namespace WpfCodeGenerator.Core.Models;

public class Parameters
{
    private string _json;
    private string _className;
    private string _language;

    public Parameters(string json, string className, string language)
    {
        _json = json;
        _className = className;
        _language = language;
    }

    public List<string> Validate()
    {
        var errorMessages = new List<string>();
        var classNameValidator = new ClassNameValidator(_className);
        var jsonValidator = new JsonValidator(_json);
        errorMessages.Add(classNameValidator.Error);
        errorMessages.Add(jsonValidator.Error);
        
        return errorMessages;
    }
}