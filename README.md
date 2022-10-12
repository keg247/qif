# qif
A library for creating and consuming *.qif files. The library complies with documented Quicken Interchange Format (QIF) files specification. It is a completely managed, open source QIF API.

This library enables you to import or export *.qif files. It also allows you to create or modify transactions and represent them easily in code as entities. This library can enable your application to completely handle any aspect of a QIF file. You can create transactions in an easy to understand model and export it to the versatile Quicken export file format, or you can easily import your QIF file, and have immediate access to all transactions in the file.


## Sponsorship

If you like the library please consider [supporting my work](https://github.com/sponsors/hazzik).

## Usage
```csharp
// This returns a QifDocument object. The QifDocument represents all transactions found in the QIF file.
QifDocument qif = QifDocument.Load(File.OpenRead(@"c:\quicken.qif"));

... /* create or modify transactions */ ...

// This writes the QifDocument to a file.
qif.Save(File.OpenWrite(@"c:\quicken.qif"));
```

All transactions present in the DOM are written according to the QIF file format specification. Dates and numbers should be written according to globalization standards.

## Available on [NuGet](http://www.nuget.org/packages/hazzik.qif)

```PowerShell
Install-Package Hazzik.Qif
```
