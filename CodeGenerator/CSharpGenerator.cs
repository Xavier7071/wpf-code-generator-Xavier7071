using System.Text.Json;

namespace CodeGenerator;

public class CSharpLanguageGenerator : LanguageGenerator
{
    public CSharpLanguageGenerator(JsonElement jsonElement, List<string> argumentNames)
    {
        ArgumentNames = argumentNames;
        StartGenerator(jsonElement);
    }

    protected override void BuildHeader()
    {
        StringBuilder.AppendLine("namespace " + ArgumentNames![0]);
        StringBuilder.AppendLine("{");
        StringBuilder.AppendLine(
            "     using System;\n     using System.Collections.Generic;\n     using System.Globalization;\n     using Newtonsoft.Json;\n     using Newtonsoft.Json.Converters;\n");
        StringBuilder.Append($"     public partial class {ArgumentNames![1]}\n");
        StringBuilder.Append("     {");
    }

    protected override void BuildObject(JsonProperty jsonObject)
    {
        var objectName = FirstCharToUpper(jsonObject.Name);
        StringBuilder.AppendLine($"\n         [JsonProperty(\"{jsonObject.Name}\")]");
        StringBuilder.Append($"         public {objectName} {objectName} ");
        StringBuilder.AppendLine("{ get; set; }");
    }

    protected override void BuildClass(JsonProperty jsonObject)
    {
        var objectName = FirstCharToUpper(jsonObject.Name);
        StringBuilder.AppendLine("     }\n");
        StringBuilder.AppendLine($"     public partial class {objectName}");
        StringBuilder.Append("     {");
    }

    protected override void BuildProperty(JsonProperty jsonProperty)
    {
        var propertyName = FirstCharToUpper(jsonProperty.Name);
        StringBuilder.AppendLine($"\n         [JsonProperty(\"{jsonProperty.Name}\")]");
        switch (jsonProperty.Value.ValueKind)
        {
            case JsonValueKind.Number:
                StringBuilder.Append($"         public long {propertyName} ");
                break;
            case JsonValueKind.True:
            case JsonValueKind.False:
                StringBuilder.Append($"         public bool {propertyName} ");
                break;
            default:
                StringBuilder.Append(
                    $"         public {jsonProperty.Value.ValueKind.ToString().ToLower()} {propertyName} ");
                break;
        }

        StringBuilder.AppendLine("{ get; set; }");
    }

    protected override void BuildArray(JsonProperty array)
    {
        var arrayName = FirstCharToUpper(array.Name);
        var arrayElement = array.Value.EnumerateArray().First();
        StringBuilder.AppendLine($"\n         [JsonProperty(\"{array.Name}\")]");
        switch (arrayElement.ValueKind)
        {
            case JsonValueKind.Object:
                StringBuilder.Append($"         public List<{arrayName}> {arrayName} ");
                break;
            case JsonValueKind.Number:
                StringBuilder.Append($"         public List<long> {arrayName} ");
                break;
            case JsonValueKind.True:
            case JsonValueKind.False:
                StringBuilder.Append($"         public List<bool> {arrayName} ");
                break;
            default:
                StringBuilder.Append(
                    $"         public List<{arrayElement.ValueKind.ToString().ToLower()}> {arrayName} ");
                break;
        }

        StringBuilder.AppendLine("{ get; set; }");
    }

    protected override void BuildFooter()
    {
        StringBuilder.Append("     }");
    }
}