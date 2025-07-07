using System.IO;
using HeavenlyHR.Export;
using HeavenlyHR.Repositories;
using System.Text;

namespace HeavenlyHR.Services
{
    public class ExportService
    {
        private readonly EmployeeRepository _employeeRepo;

        public ExportService(EmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task ExportEmployeesToCsvFileAsync(string filePath)
        {
            var employees = await _employeeRepo.GetAllAsync();
            var csv = CsvExporter.ExportEmployeesToCsv(employees);

            await File.WriteAllTextAsync(filePath, csv, Encoding.UTF8);
            Console.WriteLine($"絕對路徑：{Path.GetFullPath(filePath)}");
        }
    }
}