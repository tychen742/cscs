using System.Text.Json;

public static class NotebookValidation
{
    public static NotebookValidationResult Validate(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return NotebookValidationResult.Invalid("Notebook content is empty.");
        }

        try
        {
            using var document = JsonDocument.Parse(json);
            var root = document.RootElement;
            if (root.ValueKind != JsonValueKind.Object)
            {
                return NotebookValidationResult.Invalid("The notebook root must be a JSON object.");
            }

            if (!HasIntegerProperty(root, "nbformat") || !HasIntegerProperty(root, "nbformat_minor"))
            {
                return NotebookValidationResult.Invalid("The notebook must contain integer nbformat and nbformat_minor properties.");
            }

            if (!root.TryGetProperty("cells", out var cells) || cells.ValueKind != JsonValueKind.Array)
            {
                return NotebookValidationResult.Invalid("The notebook must contain a cells array.");
            }

            var cellNumber = 0;
            foreach (var cell in cells.EnumerateArray())
            {
                cellNumber++;
                if (cell.ValueKind != JsonValueKind.Object)
                {
                    return NotebookValidationResult.Invalid($"Cell {cellNumber} must be a JSON object.");
                }

                if (!HasStringProperty(cell, "cell_type") || !cell.TryGetProperty("source", out var source))
                {
                    return NotebookValidationResult.Invalid($"Cell {cellNumber} must contain cell_type and source.");
                }

                if (source.ValueKind != JsonValueKind.String && source.ValueKind != JsonValueKind.Array)
                {
                    return NotebookValidationResult.Invalid($"Cell {cellNumber} source must be a string or array of strings.");
                }

                if (source.ValueKind == JsonValueKind.Array && source.EnumerateArray().Any(item => item.ValueKind != JsonValueKind.String))
                {
                    return NotebookValidationResult.Invalid($"Cell {cellNumber} source arrays may contain only strings.");
                }
            }

            return NotebookValidationResult.Valid(cells.GetArrayLength());
        }
        catch (JsonException exception)
        {
            return NotebookValidationResult.Invalid($"Invalid JSON: {exception.Message}");
        }
    }

    private static bool HasIntegerProperty(JsonElement objectElement, string name) =>
        objectElement.TryGetProperty(name, out var property) && property.ValueKind == JsonValueKind.Number && property.TryGetInt32(out _);

    private static bool HasStringProperty(JsonElement objectElement, string name) =>
        objectElement.TryGetProperty(name, out var property) && property.ValueKind == JsonValueKind.String;
}

public sealed record NotebookValidationResult(bool IsValid, string Message, int CellCount)
{
    public static NotebookValidationResult Valid(int cellCount) => new(true, "Notebook is valid.", cellCount);
    public static NotebookValidationResult Invalid(string message) => new(false, message, 0);
}
