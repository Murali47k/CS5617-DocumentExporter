using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exporter;

namespace Exporter.Tests;

[TestClass]
public class CsvExporterTest : ExporterContractTest
{
    protected override IDocumentExporter CreateExporter()
    {
        return new CsvExporter();
    }

    [TestMethod]
    public void CsvExporterContract()
    {
        ExporterContract();
    }

    [TestMethod]
    public void CsvExporterFull()
    {
        // Arrange
        var document = new Document(
            "Formula 1",
            new List<string>
            {
                "RedBull Racing","Mercedes","Ferrari","McLaren"
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

}
