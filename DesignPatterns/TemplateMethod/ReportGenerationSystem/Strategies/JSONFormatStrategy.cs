using ReportGenerationSystem.Interfaces;
using ReportGenerationSystem.Templates;
using ReportGenerationSystem.Models;

namespace ReportGenerationSystem.Strategies;

public class JSONFormatStrategy : IReportFormatStrategy
{
    public string GetFormatName() => "JSON";

    public string GetFileExtension() => ".json";
  
   public string FormatReport(List<string> processedData, ReportType reportType)
    {
        Console.WriteLine($"Formatting {reportType} report as JSON...");

        var json = "{\n";
        json += $"  \"reportType\": \"{reportType}\",\n";
        json += "  \"data\": [\n";

        for (int i = 0; i < processedData.Count; i++)
        {
            json += $"    \"{processedData[i]}\"";
            if (i < processedData.Count - 1)
            {
                json += ",";
            }
            json += "\n";
        }

        json += "  ]\n";
        json += "}";

        return json;
    }

}