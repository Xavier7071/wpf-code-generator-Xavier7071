using System.Text.Json;

namespace WpfCodeGenerator.Core.Validators;

public class JsonValidator
{
    public string Error { get; private set; }

    public JsonValidator(string json)
    {
        Error = "";
        Validate(json);
    }

    private void Validate(string json)
    {
        if (json.Length == 0)
        {
            Error = "JSON (Le champ doit être rempli)";
        }
        else
        {
            try
            {
                JsonDocument.Parse(json);
            }
            catch (Exception)
            {
                Error = "JSON (Le JSON doit être valide)";
            }
        }
    }
}