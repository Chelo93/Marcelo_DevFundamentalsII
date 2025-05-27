using ProductExportApp.Models;
using ProductExportApp.Services;

namespace ProductExportApp.Tests.Services;

public class TestCsvExporter
{
  private static readonly Product[] _products =
  [
    new Product(1, "Laptop", 7999.99m, "Electronics"),
    new Product(2, "Desk", 4999.99m, "Furniture"),
    new Product(3, "Fork", 2999.99m, "Kitchen"),
  ];

  [Fact]
  public void Export_ProducesCommaSeparatedValues()
  {
    var exporter = new CsvExporter();

    var result = exporter.Export(_products);

    var expected = $"""
    Id,Name,Price,Category
    1,Laptop,7999.99,Electronics
    2,Desk,4999.99,Furniture
    3,Fork,2999.99,Kitchen
    
    """;

    Assert.Equal(expected, result);
  }

  // TODO: Add tests for the other exporter types.
  [Fact]
  public void Export_ProducesXmlFormatedString()
  {
    var exporter = new XmlExporter();

    var result = exporter.Export(_products);

    var expected = """
    <Products>
      <Product id="1">
        <Name>Laptop</Name>
        <Price>7999.99</Price>
        <Category>Electronics</Category>
      </Product>
      <Product id="2">
        <Name>Desk</Name>
        <Price>4999.99</Price>
        <Category>Furniture</Category>
      </Product>
      <Product id="3">
        <Name>Fork</Name>
        <Price>2999.99</Price>
        <Category>Kitchen</Category>
      </Product>
    </Products>

    """;

    Assert.Equal(expected, result);
  }

  [Fact]
  public void Export_ProducesJsonFormatedString()
  {
    var exporter = new JsonExporter();

    var result = exporter.Export(_products);

    var expected = """
    [
      {
        "Id": 1,
        "Name": "Laptop",
        "Price": 7999.99,
        "Category": "Electronics"
      },
      {
        "Id": 2,
        "Name": "Desk",
        "Price": 4999.99,
        "Category": "Furniture"
      },
      {
        "Id": 3,
        "Name": "Fork",
        "Price": 2999.99,
        "Category": "Kitchen"
      }
    ]
    """;

    Assert.Equal(expected, result);
  }

  [Fact]
  public void Export_ProducesYamlFormatedString()
  {
    var exporter = new YamlExporter();

    var result = exporter.Export(_products);

    var expected = """
    Products:
      - Product:
        Id: "1"
        Name: "Laptop"
        Price: "7999.99"
        Category: "Electronics"
      - Product:
        Id: "2"
        Name: "Desk"
        Price: "4999.99"
        Category: "Furniture"
      - Product:
        Id: "3"
        Name: "Fork"
        Price: "2999.99"
        Category: "Kitchen"

    """;

    Assert.Equal(expected, result);
  }

}