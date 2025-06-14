using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Strategies;
using ReportGenerationSystem.Models;

namespace ReportGenerationSystem.Templates;

public abstract class ReportGenerator(IReportFormatStrategy? formatStrategy = null)
{
  protected IReportFormatStrategy _formatStrategy = formatStrategy ?? new HTMLFormatStrategy();

  public void SetFormatStrategy(IReportFormatStrategy formatStrategy)
  {
    _formatStrategy = formatStrategy ?? throw new ArgumentNullException(nameof(formatStrategy));
    Console.WriteLine($"Format strategy changed to: {formatStrategy.GetFormatName()}");
  }

  public string GenerateReport()
  {
    Console.WriteLine($"\nGenerating {GetReportType()} Report");

    var rawData = FectchData();
    var processedData = ProcessedData(rawData);
    //var formattedReport = FormatReport(processedData);
    var formattedReport = _formatStrategy.FormatReport(processedData, GetReportType());
    SaveReport(formattedReport);

    return formattedReport;
  }

  // TODO: Convert into enum (the report type)
  protected abstract ReportType GetReportType();
  protected abstract string[] FectchData();
  protected abstract List<string> ProcessedData(string[] rawData);
  // protected abstract string FormatReport(List<string> processedData);

  // NOTE: LSP being broken
  // protected virtual void ExtraStep()
  // {
  //   if (GetReportType() != "Scores")
  //   {
  //     throw new Exception();
  //   }

  //   // something for the extra step
  // }

  protected virtual void SaveReport(string report)
  {
    Console.WriteLine($"💾 Saving {GetReportType()} report to file...");
    Console.WriteLine($"Report saved successfully: {report.Length} characters\n");
  }

}