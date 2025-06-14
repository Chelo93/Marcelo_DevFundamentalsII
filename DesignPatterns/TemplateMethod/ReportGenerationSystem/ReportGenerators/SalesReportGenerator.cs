using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Templates;
using ReportGenerationSystem.Models;

namespace ReportGenerationSystem.ReportGenerators;

public class SalesReportGenerator(IReportFormatStrategy? formatStrategy = null) : ReportGenerator(formatStrategy)
{
    protected override ReportType GetReportType() => ReportType.Sales;

    protected override string[] FectchData()
  {
    Console.WriteLine("Fetching sales data from database...");

    return ["Sale 1: $100", "Sale 2: $200", "Sale 3: $400"];
  }

  protected override List<string> ProcessedData(string[] rawData)
  {
    Console.WriteLine("Processing sales data: converting to uppercase and filtering...");

    return [.. rawData
      .Select(d => d.ToUpper())
      .Where(d => d.Contains('$'))];
  }

  // protected override string FormatReport(List<string> processedData)
  // {
  //   Console.WriteLine("Formatting sales to report as HTML...");
  //   var report = "<html><body><h1>Sales Report</h1>";

  //   foreach (var item in processedData)
  //   {
  //     report += $"<p>{item}</p>";
  //   }

  //   report += "</body></html>";

  //   return report;
  // }
}