using System.Text;

namespace Exporter;

/// <summary>
/// TextExporter is an implementation of the IDocumentExporter interface that exports a document to a plain text format.
/// </summary>
public sealed class TextExporter : IDocumentExporter
{
    /// <summary>
    /// Exports the given Document to a plain text format. 
    /// The title of the document is placed on the first line, followed by each row of the document on subsequent lines.
    /// </summary>
    /// <param name="document">A simple document with a title and a collection of rows</param>
    public string Export(Document document)
    {
        ArgumentNullException.ThrowIfNull(document);

        var sb = new StringBuilder();

        sb.AppendLine(document.Title);

        foreach (string row in document.Rows)
        {
            sb.AppendLine(row);
        }
        return sb.ToString();
    }
}
