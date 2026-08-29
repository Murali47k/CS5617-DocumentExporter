using System.Text;

namespace Exporter;

/// <summary>
/// CsvExporter is an implementation of the IDocumentExporter interface that exports a Document to a csv format
/// </summary>
public sealed class CsvExporter : IDocumentExporter
{
    /// <summary>
    /// Exports the given Document to a CSV format. 
    /// The title of the document is placed on the first line, followed by each row of the document on subsequent lines. 
    /// </summary>
    /// <param name="document">A simple document with a title and a collection of rows</param>
    public string Export(Document document)
    {
        ArgumentNullException.ThrowIfNull(document);

        var sb = new StringBuilder();

        sb.AppendLine(CsvFormat(document.Title));

        foreach (string row in document.Rows)
        {
            sb.AppendLine(CsvFormat(row));
        }
        return sb.ToString();
    }

    /// <summary> 
    /// Formats the given input string according to CSV formatting rules. 
    /// Values containing commas, double quotes, or newline characters are enclosed in double quotes. 
    /// Double quotes within the value are escaped by doubling them. 
    /// </summary> 
    /// <param name="input">The string value to format as CSV.</param> 
    public static string CsvFormat(string input)
    {
        if (input.Contains(",") || input.Contains("\"") || input.Contains("\n"))
        {
            // Escape double quotes by doubling them
            string escapedInput = input.Replace("\"", "\"\"");
            return $"\"{escapedInput}\"";
        }
        return input;
    }
}

