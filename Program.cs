using HeavenlyHR.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HeavenlyHR.Repositories;
using HeavenlyHR.Services;

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

// 註冊 Repository
services.AddScoped<EmployeeRepository>();
services.AddScoped<EmployeeChangeRepository>();
services.AddScoped<CandidateRepository>();
services.AddScoped<StaffingPlanRepository>();

// 註冊 Service
services.AddScoped<EmployeeService>();
services.AddScoped<EmployeeChangeService>();
services.AddScoped<ExportService>();
services.AddScoped<CandidateService>();
services.AddScoped<StaffingPlanService>();

// 建立 ServiceProvider，日後可取出 DbContext 使用
var serviceProvider = services.BuildServiceProvider();

// 使用 scope 來取得服務並執行
using (var scope = serviceProvider.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var repo = scope.ServiceProvider.GetRequiredService<EmployeeRepository>();
    var service = scope.ServiceProvider.GetRequiredService<EmployeeService>();
    var changeService = scope.ServiceProvider.GetRequiredService<EmployeeChangeService>();
    var exportService = scope.ServiceProvider.GetRequiredService<ExportService>();
    var candidateService = scope.ServiceProvider.GetRequiredService<CandidateService>();
    Console.WriteLine("\n正在匯出員工資料到 CSV...");
    await exportService.ExportEmployeesToCsvFileAsync("employees_export.csv");
    Console.WriteLine("匯出完成！檔案位置：employees_export.csv");
    Console.WriteLine(" 從資料庫讀取員工資料（直接使用 Repository）...");
    Console.WriteLine("\n從資料庫讀取候選人資料（使用 CandidateService）...");
    
    try
    {
        var employeesFromRepo = await repo.GetAllAsync();

        Console.WriteLine($" 共找到 {employeesFromRepo.Count} 筆員工資料：");
        foreach (var emp in employeesFromRepo)
        {
            Console.WriteLine($"  {emp.FullName} - 到職日: {emp.HireDate.ToShortDateString()}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($" 發生錯誤（Repository）：{ex.Message}");
    }

    Console.WriteLine("\n 從服務層讀取員工資料（使用 EmployeeService）...");

    try
    {
        var employeesFromService = await service.GetAllAsync();

        Console.WriteLine($" 共找到 {employeesFromService.Count} 筆員工資料：");
        foreach (var emp in employeesFromService)
        {
            Console.WriteLine($"  {emp.FullName} - 到職日: {emp.HireDate.ToShortDateString()}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($" 發生錯誤（Service）：{ex.Message}");
    }

    Console.WriteLine("\n新增一筆員工異動紀錄測試...");

    var newChange = new HeavenlyHR.Models.EmployeeChange
    {
        EmployeeId = 1, // 請改成你資料庫中確實存在的員工ID
        ChangeType = HeavenlyHR.Models.ChangeType.離職,
        ChangeMethod = HeavenlyHR.Models.ChangeMethod.手動,
        EffectiveDate = new DateTime(2025, 7, 10),
        ApprovalDate = new DateTime(2025, 7, 5),
        ApplicationDate = new DateTime(2025, 7, 1),
        ChangeReason = HeavenlyHR.Models.ChangeReason.退休,
        Remark = "員工自願退休"
    };

    try
    {
        await changeService.AddAsync(newChange);
        Console.WriteLine("異動紀錄新增成功！");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"新增異動紀錄失敗：{ex.Message}");
        if (ex.InnerException != null)
        {
            Console.WriteLine($"詳細錯誤：{ex.InnerException.Message}");
        }
    }
    
    try
    {
        var candidates = await candidateService.GetAllAsync();
        Console.WriteLine($"共找到 {candidates.Count} 筆候選人資料：");
        foreach (var c in candidates)
        {
            Console.WriteLine($"  {c.FullName} - 職位申請: {c.AppliedPosition} - 狀態: {c.Status}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"讀取候選人資料失敗：{ex.Message}");
    }
    
    var staffingPlanService = scope.ServiceProvider.GetRequiredService<StaffingPlanService>();

    Console.WriteLine("\n從服務層讀取編制人力資料...");

    try
    {
        var staffingPlans = await staffingPlanService.GetAllAsync();

        Console.WriteLine($" 共找到 {staffingPlans.Count} 筆編制資料：");

        foreach (var plan in staffingPlans)
        {
            Console.WriteLine($" 年度: {plan.Year}, 部門: {plan.DepartmentName}, 職務: {plan.JobTitle}, 需求人數: {plan.PlannedHeadcount}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($" 發生錯誤（StaffingPlanService）：{ex.Message}");
    }
}
