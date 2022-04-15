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

    public void Validate()
    {
        
    }
}