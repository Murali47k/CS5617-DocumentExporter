# CS5617-DocumentExporter

### Problem Statement

#### A07 | SOLID - Liskov Substitution Principle | Document Exporters 
Design text, CSV, and JSON exporters that remain correct when used through one base contract. 

**Minimum requirements:** State the contract clearly; implement at least three substitutable exporters; avoid 
unsupported-operation exceptions; test every implementation with shared contract tests. 

### Design Overveiw


### Class Diagram
![Class Diagram](UML_DocsExporter.png)

### Project Structure
```text
DocsExporter/
│
├── Exporter/
│   ├── CsvExporter.cs
│   ├── Document.cs
│   ├── IDocumentExporter.cs
│   ├── JsonExporter.cs
│   └── TextExporter.cs
│
├── Exporter.Tests/
│   ├── CsvExporterTest.cs
│   ├── ExporterContractTest.cs
│   ├── JsonExporterTest.cs
│   └── TextExporterTest.cs
│
└── DocsExporter.sln
```

### To Build and Run 

```text 
cd DocsExporter
dotnet build
dotnet test
```

### Test cases

- Total 21 test cases
    - (4) -> TextExporter
    - (9) -> CsvExporter
    - (8) -> JsonExporter

### Test Summary 

### Critical Analysis

### Environment

Made with Visual Studio 2022