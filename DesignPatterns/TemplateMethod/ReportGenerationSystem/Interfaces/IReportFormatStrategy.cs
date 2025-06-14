namespace ReportGenerationSystem.Interfaces;

using ReportGenerationSystem.Templates;
using ReportGenerationSystem.Models;
public interface IReportFormatStrategy
{
  // TODO: Change to enum
  string GetFormatName();
  string FormatReport(List<string> processedData, ReportType reportType);
  string GetFileExtension();
}