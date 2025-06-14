using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Templates;
using ReportGenerationSystem.Models;

namespace ReportGenerationSystem.ReportGenerators;

public class UserReportGenerator(IReportFormatStrategy? formatStrategy = null) : ReportGenerator(formatStrategy)
{
  protected override ReportType GetReportType() => ReportType.User;
  protected override string[] FectchData()
  {
    Console.WriteLine("Fetching User data from database...");

    return ["User: John (Active)", "User: Jane (Inactive)", "User: Michael (Active)"];
  }

  protected override List<string> ProcessedData(string[] rawData)
  {
    Console.WriteLine("Processing User data: filtering active users only...");

    return [.. rawData.Where(d => d.Contains("Active")).Select(d => d.ToUpper())];
  }

  // protected override string FormatReport(List<string> processedData)
  // {
  //   Console.WriteLine("Formatting sales to report as JSON...");
  //   var report = "{ \"users\": [";
  //   report += string.Join(", ", processedData.Select(u => $"\"{u}\""));
  //   report += "] }";

  //   return report;
  // }
}