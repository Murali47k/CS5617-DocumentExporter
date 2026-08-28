using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exporter;

namespace Exporter.Tests;

[TestClass]
public class JsonExporterTest : ExporterContractTest
{
    protected override IDocumentExporter CreateExporter()
    {
        return new JsonExporter();
    }

    [TestMethod]
    public void JsonExporterContract()
    {
        ExporterContract();
    }

    [TestMethod]
    public void JsonExporterFull()
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

    }

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
