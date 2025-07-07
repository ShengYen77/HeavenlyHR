using HeavenlyHR.Models;
using HeavenlyHR.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeavenlyHR.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // 取得所有員工資料
        public Task<List<Employee>> GetAllAsync()
        {
            return _employeeRepository.GetAllAsync();
        }

        // 根據 Id 取得員工
        public Task<Employee> GetByIdAsync(int id)
        {
            return _employeeRepository.GetByIdAsync(id);
        }

        // 新增員工
        public Task AddAsync(Employee employee)
        {
            return _employeeRepository.AddAsync(employee);
        }

        // 更新員工
        public Task UpdateAsync(Employee employee)
        {
            return _employeeRepository.UpdateAsync(employee);
        }

        // 刪除員工
        public Task DeleteAsync(int id)
        {
            return _employeeRepository.DeleteAsync(id);
        }
    }
}