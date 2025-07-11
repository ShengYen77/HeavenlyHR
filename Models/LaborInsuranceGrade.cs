namespace HeavenlyHR.Models;

public class LaborInsuranceGrade
{
    public int Level { get; set; }                   // 等級（第幾級）
    public decimal SalaryFrom { get; set; }          // 月薪資下限
    public decimal SalaryTo { get; set; }            // 月薪資上限
    public decimal InsuredSalary { get; set; }       // 月投保薪資
    public decimal EmployerRate { get; set; }        // 雇主負擔比率（例：0.7 = 70%）
    public decimal EmployeeRate { get; set; }        // 員工負擔比率（例：0.2 = 20%）
    public decimal GovernmentRate { get; set; }      // 政府負擔比率（例：0.1 = 10%）
    
    public decimal InsuranceRate { get; set; } = 0.12m; // 新增費率（例如 0.12 表示 12%）
}