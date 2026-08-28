using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exporter;
public interface IDocumentExporter
{
    string Export(Document document);

}
