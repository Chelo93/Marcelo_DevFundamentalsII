using ReportGenerationSystem.Services;
using ReportGenerationSystem.Models;

var reportService = new ReportService();
reportService.GenerateAllReports();
reportService.GenerateAllReportsInFormat(ReportFormat.Csv);
