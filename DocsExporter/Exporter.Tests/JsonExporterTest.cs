using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exporter;
using System.Text.Json;

namespace Exporter.Tests;

/// <summary>
/// Tests the JsonExporter implementation.
/// </summary>
[TestClass]
public class JsonExporterTest : ExporterContractTest
{
    /// <summary>
    /// Creates a JsonExporter instance for testing.
    /// </summary>
    protected override IDocumentExporter CreateExporter()
    {
        return new JsonExporter();
    }

    /// <summary>
    /// Tests that JsonExporter satisfies the common exporter contract.
    /// </summary>
    [TestMethod]
    public void JsonExporterContract()
    {
        ExporterContract();
    }

    /// <summary>
    /// Tests exporting a document containing multiple rows to JSON.
    /// </summary>
    [TestMethod]
    public void JsonExporterFull()
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
        Assert.IsTrue(result.Contains("Formula 1"));
        Assert.IsTrue(result.Contains("RedBull Racing"));
        Assert.IsTrue(result.Contains("Mercedes"));
        Assert.IsTrue(result.Contains("Ferrari"));
        Assert.IsTrue(result.Contains("McLaren"));
    }

    /// <summary>
    /// Tests exporting a document with no rows.
    /// </summary>
    [TestMethod]
    public void JsonExporterNoContent()
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
        Assert.IsTrue(result.Contains("[]"));
    }

    /// <summary>
    /// Tests that exporting a null document throws an ArgumentNullException.
    /// </summary>
    [TestMethod]
    public void JsonExporterNoDocument()
    {
        // Arrange
        IDocumentExporter exporter = CreateExporter();

        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(
            () => exporter.Export(null!)
        );
    }

    
}
