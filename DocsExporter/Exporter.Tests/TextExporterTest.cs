using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exporter;

namespace Exporter.Tests;

/// <summary>
/// Tests the TextExporter implementation.
/// </summary>
[TestClass]
public class TextExporterTest : ExporterContractTest
{
    /// <summary>
    /// Creates a TextExporter instance for testing.
    /// </summary>
    protected override IDocumentExporter CreateExporter()
    {
        return new TextExporter();
    }

    /// <summary>
    /// Tests that TextExporter satisfies the common exporter contract.
    /// </summary>
    [TestMethod]
    public void TextExporterContract()
    {
        ExporterContract();
    }

    /// <summary>
    /// Tests exporting a document containing multiple rows.
    /// </summary>
    [TestMethod]
    public void TextExporterFull()
    {
        // Arrange
        var document = new Document(
            "Formula 1",
            new List<string>
            {
                "RedBull Racing", "Mercedes", "Ferrari", "McLaren"
            }
        );

        IDocumentExporter exporter = CreateExporter();

        // Act
        string result = exporter.Export(document);

        // Assert
        string expected =
            "Formula 1" + Environment.NewLine +
            "RedBull Racing" + Environment.NewLine +
            "Mercedes" + Environment.NewLine +
            "Ferrari" + Environment.NewLine +
            "McLaren" + Environment.NewLine;

        Assert.AreEqual(expected, result);
    }

    /// <summary>
    /// Tests exporting a document with no rows.
    /// </summary>
    [TestMethod]
    public void TextExporterNoContent()
    {
        // Arrange
        var document = new Document(
            "EmptyList",
            new List<string> { }
        );

        IDocumentExporter exporter = CreateExporter();

        // Act
        string result = exporter.Export(document);

        // Assert
        Assert.IsTrue(result.Contains("EmptyList"));
    }

    /// <summary>
    /// Tests that exporting a null document throws an ArgumentNullException.
    /// </summary>
    [TestMethod]
    public void TextExporterNoDocument()
    {
        // Arrange
        IDocumentExporter exporter = CreateExporter();

        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(
            () => exporter.Export(null!)
        );
    }
}
