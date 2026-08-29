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

    /// <summary>
    /// Tests that the exported result is valid JSON.
    /// </summary>
    [TestMethod]
    public void JsonExporterValidJson()
    {
        // Arrange
        var document = new Document(
            "Formula 1",
            new List<string>
            {
                "RedBull Racing", "Mercedes"
            }
        );

        IDocumentExporter exporter = CreateExporter();

        // Act
        string result = exporter.Export(document);

        // Assert
        JsonDocument json = JsonDocument.Parse(result);
        Assert.IsNotNull(json);
    }

    /// <summary>
    /// Tests that the exported JSON contains the correct title and rows.
    /// </summary>
    [TestMethod]
    public void JsonExporterCorrectStructure()
    {
        // Arrange
        var document = new Document(
            "Formula 1",
            new List<string>
            {
                "RedBull Racing", "Mercedes"
            }
        );

        IDocumentExporter exporter = CreateExporter();

        // Act
        string result = exporter.Export(document);

        // Assert
        using JsonDocument json = JsonDocument.Parse(result);

        Assert.AreEqual(
            "Formula 1",
            json.RootElement.GetProperty("Title").GetString()
        );

        JsonElement rows = json.RootElement.GetProperty("Rows");

        Assert.AreEqual(2, rows.GetArrayLength());
        Assert.AreEqual("RedBull Racing", rows[0].GetString());
        Assert.AreEqual("Mercedes", rows[1].GetString());
    }

    /// <summary>
    /// Tests that special characters are correctly serialized into JSON.
    /// </summary>
    [TestMethod]
    public void JsonExporterSpecialCharacters()
    {
        // Arrange
        var document = new Document(
            "Formula \"1\"",
            new List<string>
            {
                "RedBull\nRacing",
                "Mercedes\tAMG"
            }
        );

        IDocumentExporter exporter = CreateExporter();

        // Act
        string result = exporter.Export(document);

        // Assert
        using JsonDocument json = JsonDocument.Parse(result);

        Assert.AreEqual(
            "Formula \"1\"",
            json.RootElement.GetProperty("Title").GetString()
        );

        JsonElement rows = json.RootElement.GetProperty("Rows");

        Assert.AreEqual("RedBull\nRacing", rows[0].GetString());
        Assert.AreEqual("Mercedes\tAMG", rows[1].GetString());
    }

    /// <summary>
    /// Tests that an empty title is correctly serialized into JSON.
    /// </summary>
    [TestMethod]
    public void JsonExporterEmptyTitle()
    {
        // Arrange
        var document = new Document(
            "",
            new List<string>
            {
                "RedBull Racing"
            }
        );

        IDocumentExporter exporter = CreateExporter();

        // Act
        string result = exporter.Export(document);

        // Assert
        using JsonDocument json = JsonDocument.Parse(result);

        Assert.AreEqual(
            "",json.RootElement.GetProperty("Title").GetString()
        );
    }
}
