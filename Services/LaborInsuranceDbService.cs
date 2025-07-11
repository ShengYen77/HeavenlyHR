using HeavenlyHR.Data;
using HeavenlyHR.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeavenlyHR.Services
{
    public class LaborInsuranceDbService : ILaborInsuranceService
    {
        private readonly AppDbContext _context;

        public LaborInsuranceDbService(AppDbContext context)
        {
            _context = context;
        }

        public decimal GetInsuredSalary(decimal salary)
        {
            var grade = _context.LaborInsuranceGrades
                        .FirstOrDefault(g => salary >= g.SalaryFrom && salary <= g.SalaryTo);
            return grade?.InsuredSalary ?? 0;
        }

        public decimal CalculateEmployeeContribution(decimal salary)
        {
            var grade = _context.LaborInsuranceGrades
                        .FirstOrDefault(g => salary >= g.SalaryFrom && salary <= g.SalaryTo);
            if (grade == null) return 0;
            return Math.Round(grade.InsuredSalary * grade.InsuranceRate * grade.EmployeeRate);
        }

        public decimal CalculateEmployerContribution(decimal salary)
        {
            var grade = _context.LaborInsuranceGrades
                        .FirstOrDefault(g => salary >= g.SalaryFrom && salary <= g.SalaryTo);
            if (grade == null) return 0;
            return Math.Round(grade.InsuredSalary * grade.InsuranceRate * grade.EmployerRate);
        }

        public decimal CalculateGovernmentContribution(decimal salary)
        {
            var grade = _context.LaborInsuranceGrades
                        .FirstOrDefault(g => salary >= g.SalaryFrom && salary <= g.SalaryTo);
            if (grade == null) return 0;
            return Math.Round(grade.InsuredSalary * grade.InsuranceRate * grade.GovernmentRate);
        }

        // ✅ 取得所有員工並計算勞保
        public async Task<List<Employee>> GetAllEmployeesWithContributionsAsync()
        {
            var employees = await _context.Employees
                                .Include(e => e.LaborInsuranceGrade)
                                .ToListAsync();

            foreach (var emp in employees)
            {
                if (emp.LaborInsuranceGrade != null)
                {
                    emp.InsuredSalary = emp.LaborInsuranceGrade.InsuredSalary;
                    emp.EmployeeContribution = Math.Round(emp.LaborInsuranceGrade.InsuredSalary * emp.LaborInsuranceGrade.EmployeeRate * emp.LaborInsuranceGrade.InsuranceRate);
                    emp.EmployerContribution = Math.Round(emp.LaborInsuranceGrade.InsuredSalary * emp.LaborInsuranceGrade.EmployerRate * emp.LaborInsuranceGrade.InsuranceRate);
                    emp.GovernmentContribution = Math.Round(emp.LaborInsuranceGrade.InsuredSalary * emp.LaborInsuranceGrade.GovernmentRate * emp.LaborInsuranceGrade.InsuranceRate);
                }
            }

            return employees;
        }
    }
}
