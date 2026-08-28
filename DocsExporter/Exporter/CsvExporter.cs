using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exporter;
public sealed class CsvExporter : IDocumentExporter
{
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

