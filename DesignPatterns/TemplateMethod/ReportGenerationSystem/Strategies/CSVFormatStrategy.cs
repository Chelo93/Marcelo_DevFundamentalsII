using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Templates;
using ReportGenerationSystem.Models;

namespace ReportGenerationSystem.Strategies;

public class CSVFormatStrategy(string delimiter = ",") : IReportFormatStrategy
{
  private readonly string _delimiter = delimiter;

  public string GetFormatName() => "CSV";

  public string GetFileExtension() => ".csv";

  public string FormatReport(List<string> processedData, ReportType reportType)
  {
    Console.WriteLine($"Formatting {reportType} report as CSV with delimiter '{_delimiter}'...");

    var csv = $"Generated{_delimiter}{DateTime.Now:yyyy-MM-dd:mm:ss}\n\n";
    csv += "Item,Details\n";

    foreach (var item in processedData)
    {
      var parts = item.Split(':');

      if (parts.Length >= 2)
      {
        csv += $"{parts[0].Trim()}{_delimiter}{parts[1].Trim()}\n";
      }
      else
      {
        csv += $"{item}{_delimiter}\n";
      }
    }

    return csv;
  }
}