namespace HeavenlyHR.Models;

public class EmployeeSalary
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public double MonthlySalary { get; set; }

    public bool IsLaborInsured { get; set; } = true;
    public int InsuranceSalaryLevel { get; set; } // 對應 LaborInsuranceGrade 中的 SalaryLevel

}