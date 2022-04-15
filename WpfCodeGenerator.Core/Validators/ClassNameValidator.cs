namespace WpfCodeGenerator.Core.Validators;

public class ClassNameValidator
{
    public string Error { get; private set; }
    
    public ClassNameValidator(string className)
    {
        Error = "";
        Validate(className);
    }

    private void Validate(string className)
    {
        if (className.Length == 0)
        {
            Error = "Nom de la classe (Le champ doit être rempli)";
        }
        else if (!className.Contains('.'))
        {
            Error = "Nom de la classe (Le champ doit être valide)";
        }
    }
}