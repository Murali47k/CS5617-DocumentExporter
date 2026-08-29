# CS5617-DocumentExporter


## Class Diagram
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


### Environment

Made with Visual Studio 2022