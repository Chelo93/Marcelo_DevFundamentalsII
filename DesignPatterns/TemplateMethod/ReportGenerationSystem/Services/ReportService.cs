using ReportGenerationSystem.Factories;
using ReportGenerationSystem.ReportGenerators;
using ReportGenerationSystem.Templates;
using ReportGenerationSystem.Models;

namespace ReportGenerationSystem.Services;

public class ReportService
{
  public void GenerateAllReports()
  {
    var generators = new List<ReportGenerator>
    {
      new SalesReportGenerator(),
      new InventoryReportGenerator(),
      new UserReportGenerator()
    };

    foreach (var generator in generators)
    {
      generator.GenerateReport();
    }
  }

  // TODO: This should be an enum 'format'
  public void GenerateAllReportsInFormat(ReportFormat format)
  {
    var strategy = FormatStrategyFactory.CreateStrategy(format);

    var generators = new List<ReportGenerator>
    {
      new SalesReportGenerator(strategy),
      new InventoryReportGenerator(strategy),
      new UserReportGenerator(strategy)
    };

    foreach (var generator in generators)
    {
      generator.GenerateReport();
    }
  }
}