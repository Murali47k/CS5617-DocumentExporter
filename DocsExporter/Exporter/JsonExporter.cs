using System.Text.Json;

namespace Exporter;

/// <summary>
/// JsonExporter is an implementation of the IDocumentExporter interface that exports a document to a json format
/// </summary>
public sealed class JsonExporter : IDocumentExporter
{
    /// <summary> 
    /// Exports the given Document to a JSON format. 
    /// The document's title and collection of rows are serialized into a JSON string. 
    /// </summary>
    /// <param name="document">A simple document with a title and a collection of rows</param>
    public string Export(Document document)
    {
        ArgumentNullException.ThrowIfNull(document);

        return JsonSerializer.Serialize(document);
    }
}
