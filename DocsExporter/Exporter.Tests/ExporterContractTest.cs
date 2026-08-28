using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exporter;

namespace Exporter.Tests;

public abstract class ExporterContractTest
{
    protected abstract IDocumentExporter CreateExporter();

    protected void ExporterContract()
    {
        // Arrange
        var document = new Document(
            "Test Document",
            new List<string>
            {
                "First row","Second row","Third row"
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
