namespace Exporter;

/// <summary>
/// Interface for various document exporter implementations. It defines a method to export a document to a specific format.
/// </summary>
public interface IDocumentExporter
{
    string Export(Document document);

}
