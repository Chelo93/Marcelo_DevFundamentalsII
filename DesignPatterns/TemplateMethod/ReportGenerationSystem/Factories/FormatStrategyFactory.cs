using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Strategies;
using ReportGenerationSystem.Models;

namespace ReportGenerationSystem.Factories;

public static class FormatStrategyFactory
{
  // TODO: Implement the missing format (json)
  public static IReportFormatStrategy CreateStrategy(ReportFormat formatName)
  {
    if (!Enum.IsDefined(typeof(ReportFormat), formatName))
    {
      throw new ArgumentException($"Unknown format: {formatName}", nameof(formatName));
    }
    // Convert the enum to a string and use it to determine the strategy
    string formatNames = formatName.ToString();
    return formatNames.ToUpper() switch
    {
      "HTML" => new HTMLFormatStrategy(),
      "CSV" => new CSVFormatStrategy(),
      "JSON" => new JSONFormatStrategy(),
      _ => throw new ArgumentException($"Unknown format: {formatName}")
    };
  }

  // TODO: Find a cleaner way to do this
  public static List<string> GetAvailableFormats()
  {
    return Enum.GetNames(typeof(ReportFormat)).ToList();
  }
}