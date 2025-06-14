using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Templates;
using ReportGenerationSystem.Models;

namespace ReportGenerationSystem.Strategies;

public class HTMLFormatStrategy : IReportFormatStrategy
{
  public string GetFormatName() => "HTML";

  public string GetFileExtension() => ".html";

  public string FormatReport(List<string> processedData, ReportType reportType)
  {
    Console.WriteLine($"Formatting {reportType} report as HTML...");

    var html = $"<html><body><h1>{reportType} Report</h1>";

    foreach (var item in processedData)
    {
      html += $"<p>{item}</p>";
    }

    html += "</body></html>";

    return html;
  }
  
}