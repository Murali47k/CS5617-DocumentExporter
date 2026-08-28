using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exporter;

public sealed record Document(string Title, IReadOnlyList<string> Rows);
