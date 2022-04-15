using WpfCodeGenerator.Core.Services;
using WpfCodeGenerator.Core.Validators;

namespace WpfCodeGenerator.Core.Models;

public class Parameters
{
    private readonly string _json;
    private readonly string _className;
    private readonly string _language;

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

    public string Convert()
    {
        var generatorService = new GeneratorService(_json, _className, _language);
        return generatorService.ConvertedJson;
    }
}