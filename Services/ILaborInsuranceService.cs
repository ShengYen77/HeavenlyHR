using HeavenlyHR.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeavenlyHR.Services
{
    public interface ILaborInsuranceService
    {
        decimal GetInsuredSalary(decimal salary);
        decimal CalculateEmployeeContribution(decimal salary);
        decimal CalculateEmployerContribution(decimal salary);
        decimal CalculateGovernmentContribution(decimal salary);

        // 新增：取得所有員工及計算勞保
        Task<List<Employee>> GetAllEmployeesWithContributionsAsync();
    }
}