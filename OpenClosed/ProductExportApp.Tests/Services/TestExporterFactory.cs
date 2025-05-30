using ProductExportApp.Interfaces;
using ProductExportApp.Models;
using ProductExportApp.Services;

namespace ProductExportApp.Tests.Services;

public class TestExporterFactory
{
    // TODO: Test that we can add exporters in our simplified factory
    public sealed class StubWordExporter : IProductExporter
    {
        public bool Called { get; private set; }

        public FormatType FormatKey => FormatType.Csv;

        public string Export(IEnumerable<Product> products)
        {
            Called = true;
            return "Word Exported";
        }
    }

    public sealed class StubWordExporterFactory : IExporterFactory
    {
        private readonly StubWordExporter _exporter;

        public StubWordExporterFactory(StubWordExporter exporter)
        {
            _exporter = exporter;
        }

        public string Export(IEnumerable<Product> products, FormatType formatType)
        {
            if (formatType != FormatType.Csv)
            {
                throw new NotSupportedException($"Export format '{formatType}' is not supported.");
            }

            return _exporter.Export(products);
        }
    }

    [Fact]
    public void ExporterFactory_CallsWordExporter()
    {

        var stubExporter = new StubWordExporter();
        var factory = new StubWordExporterFactory(stubExporter);
        var products = new List<Product>
        {
            new Product(1, "Test Product", 100.00m, "Test Category"),
            new Product(2, "Another Product", 200.00m, "Test Category")
        };

        var result = factory.Export(products, FormatType.Csv);

        Assert.True(stubExporter.Called);
        Assert.Equal("Word Exported", result);
    }

}
