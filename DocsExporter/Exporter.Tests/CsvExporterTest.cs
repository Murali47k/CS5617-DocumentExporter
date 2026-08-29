using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exporter;

namespace Exporter.Tests;

/// <summary>
/// Tests the CsvExporter implementation.
/// </summary>
[TestClass]
public class CsvExporterTest : ExporterContractTest
{
    /// <summary>
    /// Creates a CsvExporter instance for testing.
    /// </summary>
    protected override IDocumentExporter CreateExporter()
    {
        return new CsvExporter();
    }

    /// <summary>
    /// Tests that CsvExporter satisfies the common exporter contract.
    /// </summary>
    [TestMethod]
    public void CsvExporterContract()
    {
        ExporterContract();
    }

    /// <summary>
    /// Tests exporting a document containing multiple rows to CSV.
    /// </summary>
    [TestMethod]
    public void CsvExporterFull()
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
    public void CsvExporterNoContent()
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
    public void CsvExporterNoDocument()
    {
        // Arrange
        IDocumentExporter exporter = CreateExporter();

        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(
            () => exporter.Export(null!)
        );
    }

    /// <summary>
    /// Tests that CSV values containing commas are enclosed in double quotes.
    /// </summary>
    [TestMethod]
    public void CsvExporterComma()
    {
        // Arrange
        var document = new Document(
            "Teams",
            new List<string>
            {
                "RedBull Racing, Austria",
                "Ferrari, Italy"
            }
        );

        IDocumentExporter exporter = CreateExporter();

        // Act
        string result = exporter.Export(document);

        // Assert
        Assert.IsTrue(result.Contains("\"RedBull Racing, Austria\""));
        Assert.IsTrue(result.Contains("\"Ferrari, Italy\""));
    }

    /// <summary>
    /// Tests that double quotes in CSV values are escaped by doubling them.
    /// </summary>
    [TestMethod]
    public void CsvExporterQuotes()
    {
        // Arrange
        var document = new Document(
            "Teams",
            new List<string>
            {
                "Red \"Bull\" Racing"
            }
        );

        IDocumentExporter exporter = CreateExporter();

        // Act
        string result = exporter.Export(document);

        // Assert
        Assert.IsTrue(result.Contains("\"Red \"\"Bull\"\" Racing\""));
    }

    /// <summary>
    /// Tests that CSV values containing newline characters are enclosed in double quotes.
    /// </summary>
    [TestMethod]
    public void CsvExporterNewLine()
    {
        // Arrange
        var document = new Document(
            "Teams",
            new List<string>
            {
                "RedBull\nRacing"
            }
        );

        IDocumentExporter exporter = CreateExporter();

        // Act
        string result = exporter.Export(document);

        // Assert
        Assert.IsTrue(result.Contains("\"RedBull\nRacing\""));
    }

    /// <summary>
    /// Tests that CSV values without special characters are not enclosed in quotes.
    /// </summary>
    [TestMethod]
    public void CsvExporterNormalValue()
    {
        // Arrange
        var document = new Document(
            "Teams",
            new List<string>
            {
                "RedBull Racing"
            }
        );

        IDocumentExporter exporter = CreateExporter();

        // Act
        string result = exporter.Export(document);

        // Assert
        Assert.IsTrue(result.Contains("RedBull Racing"));
        Assert.IsFalse(result.Contains("\"RedBull Racing\""));
    }

    /// <summary>
    /// Empty string edge case for CsvFormat method.
    /// </summary>
    [TestMethod]
    public void CsvFormatEmptyString()
    {
        // Arrange
        string input = "";

        // Act
        string result = CsvExporter.CsvFormat(input);

        // Assert
        Assert.AreEqual("", result);
    }
}
