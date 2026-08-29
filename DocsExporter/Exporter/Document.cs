namespace Exporter;

/// <summary>
/// Document represents a simple document with a title and a collection of rows.
/// </summary>
/// <param name="Title">Name of the document</param>
/// <param name="Rows">List of information in document</param>
public sealed record Document(string Title, IReadOnlyList<string> Rows);
