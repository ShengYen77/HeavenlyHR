using HeavenlyHR.Models;

namespace HeavenlyHR.Services
{
    public class LaborInsuranceService
    {
        private readonly List<LaborInsuranceGrade> _gradeTable;

        public LaborInsuranceService()
        {
            _gradeTable = new List<LaborInsuranceGrade>
            {
                new() { Level = 1, SalaryFrom = 0, SalaryTo = 28590, InsuredSalary = 28590, EmployerRate = 0.7m, EmployeeRate = 0.2m, GovernmentRate = 0.1m },
                new() { Level = 2, SalaryFrom = 28591, SalaryTo = 28800, InsuredSalary = 28800, EmployerRate = 0.7m, EmployeeRate = 0.2m, GovernmentRate = 0.1m },
                new() { Level = 3, SalaryFrom = 28801, SalaryTo = 30300, InsuredSalary = 30300, EmployerRate = 0.7m, EmployeeRate = 0.2m, GovernmentRate = 0.1m },
                new() { Level = 4, SalaryFrom = 30301, SalaryTo = 31800, InsuredSalary = 31800, EmployerRate = 0.7m, EmployeeRate = 0.2m, GovernmentRate = 0.1m },
                new() { Level = 5, SalaryFrom = 31801, SalaryTo = 33300, InsuredSalary = 33300, EmployerRate = 0.7m, EmployeeRate = 0.2m, GovernmentRate = 0.1m },
                new() { Level = 6, SalaryFrom = 33301, SalaryTo = 34800, InsuredSalary = 34800, EmployerRate = 0.7m, EmployeeRate = 0.2m, GovernmentRate = 0.1m },
                new() { Level = 7, SalaryFrom = 34801, SalaryTo = 36300, InsuredSalary = 36300, EmployerRate = 0.7m, EmployeeRate = 0.2m, GovernmentRate = 0.1m },
                new() { Level = 8, SalaryFrom = 36301, SalaryTo = 38200, InsuredSalary = 38200, EmployerRate = 0.7m, EmployeeRate = 0.2m, GovernmentRate = 0.1m },
                new() { Level = 9, SalaryFrom = 38201, SalaryTo = 40100, InsuredSalary = 40100, EmployerRate = 0.7m, EmployeeRate = 0.2m, GovernmentRate = 0.1m },
                new() { Level = 10, SalaryFrom = 40101, SalaryTo = 42000, InsuredSalary = 42000, EmployerRate = 0.7m, EmployeeRate = 0.2m, GovernmentRate = 0.1m },
                new() { Level = 11, SalaryFrom = 42001, SalaryTo = 43900, InsuredSalary = 43900, EmployerRate = 0.7m, EmployeeRate = 0.2m, GovernmentRate = 0.1m },
                new() { Level = 12, SalaryFrom = 43901, SalaryTo = decimal.MaxValue, InsuredSalary = 45800, EmployerRate = 0.7m, EmployeeRate = 0.2m, GovernmentRate = 0.1m },
            };
        }

        public LaborInsuranceGrade? GetGradeBySalary(decimal salary)
        {
            return _gradeTable.FirstOrDefault(g =>
                salary >= g.SalaryFrom && salary <= g.SalaryTo);
        }

        public decimal CalculateEmployeeContribution(decimal salary)
        {
            var grade = GetGradeBySalary(salary);
            if (grade == null) return 0;

            return Math.Round(grade.InsuredSalary * grade.InsuranceRate * grade.EmployeeRate);
        }

        public decimal CalculateEmployerContribution(decimal salary)
        {
            var grade = GetGradeBySalary(salary);
            if (grade == null) return 0;

            return Math.Round(grade.InsuredSalary * grade.InsuranceRate * grade.EmployerRate);
        }

        public decimal CalculateGovernmentContribution(decimal salary)
        {
            var grade = GetGradeBySalary(salary);
            if (grade == null) return 0;

            return Math.Round(grade.InsuredSalary * grade.InsuranceRate * grade.GovernmentRate);
        }

        public decimal GetInsuredSalary(decimal salary)
        {
            return GetGradeBySalary(salary)?.InsuredSalary ?? 0;
        }
    }
}