using HeavenlyHR.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HeavenlyHR.Repositories;

var services = new ServiceCollection();

// 讀取 appsettings.json 中的連線字串
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");

// 註冊 AppDbContext（使用 MySQL）
services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
services.AddScoped<EmployeeRepository>();


// 建立 ServiceProvider，日後可取出 DbContext 使用
var serviceProvider = services.BuildServiceProvider();

// 測試是否成功連線
using (var scope = serviceProvider.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var repo = scope.ServiceProvider.GetRequiredService<EmployeeRepository>();

    Console.WriteLine(" 從資料庫讀取員工資料...");

    try
    {
        var employees = await repo.GetAllAsync();

        Console.WriteLine($" 共找到 {employees.Count} 筆員工資料：");
        foreach (var emp in employees)
        {
            Console.WriteLine($"  {emp.FullName} - 到職日: {emp.HireDate.ToShortDateString()}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($" 發生錯誤：{ex.Message}");
    }
}
