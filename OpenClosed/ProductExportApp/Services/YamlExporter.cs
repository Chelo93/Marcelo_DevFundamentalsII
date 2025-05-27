using System.Text;
using ProductExportApp.Interfaces;
using ProductExportApp.Models;

namespace ProductExportApp.Services;

public class YamlExporter : IProductExporter
{
  public FormatType FormatKey => FormatType.Yaml;

  public string Export(IEnumerable<Product> products)
  {
    var yaml = new StringBuilder();
    yaml.AppendLine("Products:");
    foreach (var product in products)
    {
      yaml.AppendLine($"""
        - Product:
          Id: "{product.Id}"
          Name: "{product.Name}"
          Price: "{product.Price}"
          Category: "{product.Category}"
      """);  
    }

    return yaml.ToString();
  }
}