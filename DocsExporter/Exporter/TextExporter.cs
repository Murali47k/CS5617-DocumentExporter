using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exporter;
public sealed class TextExporter : IDocumentExporter
{
    public string Export(Document document)
    {
        var sb = new StringBuilder();

        sb.AppendLine(document.Title);

        foreach (string row in document.Rows)
        {
            sb.AppendLine(row);
        }
        return sb.ToString();
    }
}
