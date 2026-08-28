using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Exporter;
public sealed class JsonExporter : IDocumentExporter
{
    public string Export(Document document)
    {
        ArgumentNullException.ThrowIfNull(document);

        return JsonSerializer.Serialize(document);
    }
}
