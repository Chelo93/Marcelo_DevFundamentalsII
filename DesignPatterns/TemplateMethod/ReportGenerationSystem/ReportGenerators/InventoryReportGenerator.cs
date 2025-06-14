using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Templates;
using ReportGenerationSystem.Models;

namespace ReportGenerationSystem.ReportGenerators;

public class InventoryReportGenerator(IReportFormatStrategy? formatStrategy = null) : ReportGenerator(formatStrategy)
{
  protected override ReportType GetReportType() => ReportType.Inventory;

  protected override string[] FectchData()
  {
    Console.WriteLine("Fetching Inventory data from database...");

    return ["Product A: 50 units", "Product B: 30 units", "Product C: 10 units"];
  }

  protected override List<string> ProcessedData(string[] rawData)
  {
    Console.WriteLine("Processing Inventory data: filtering out-of-stock items...");

    return [.. rawData
      .Where(d => d.Contains(": 0 units"))
      .Select(d => d.ToUpper())];
  }

  // protected override string FormatReport(List<string> processedData)
  // {
  //   Console.WriteLine("Formatting sales to report as CSV...");
  //   var report = "Product,Quantity\n";

  //   foreach (var item in processedData)
  //   {
  //     var parts = item.Split(':');
  //     report += $"{parts[0]},{parts[1].Trim()}\n";
  //   }

  //   return report;
  // }
}