using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exporter;

namespace Exporter.Tests;

/// <summary>
/// Defines the common contract tests that every document exporter must satisfy.
/// </summary>
public abstract class ExporterContractTest
{
    /// <summary>
    /// Creates an instance of the document exporter being tested.
    /// </summary>
    protected abstract IDocumentExporter CreateExporter();

    /// <summary>
    /// Verifies that an exporter produces a non-empty result containing the document title and all document rows.
    /// </summary>
    protected void ExporterContract()
    {
        // Arrange
        var document = new Document(
            "Test Document",
            new List<string>
            {
                "First row", "Second row", "Third row"
            }
        );

        IDocumentExporter exporter = CreateExporter();

        // Act
        string result = exporter.Export(document);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsFalse(string.IsNullOrEmpty(result));
        Assert.IsTrue(result.Contains(document.Title));

        foreach (string row in document.Rows)
        {
            Assert.IsTrue(result.Contains(row));
        }
    }
}
