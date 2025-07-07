using System.Collections.Generic;
using System.Threading.Tasks;
using HeavenlyHR.Models;
using HeavenlyHR.Repositories;

namespace HeavenlyHR.Services
{
    public class EmployeeChangeService
    {
        private readonly EmployeeChangeRepository _repository;

        public EmployeeChangeService(EmployeeChangeRepository repository)
        {
            _repository = repository;
        }

        // 取得所有異動紀錄
        public async Task<List<EmployeeChange>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        // 根據 Id 取得異動紀錄
        public async Task<EmployeeChange> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // 新增異動紀錄
        public async Task AddAsync(EmployeeChange change)
        {
            // 後續這裡可以加業務邏輯驗證或其他處理

            await _repository.AddAsync(change);
        }

        // 更新異動紀錄
        public async Task UpdateAsync(EmployeeChange change)
        {
            // 後續可以加邏輯判斷

            await _repository.UpdateAsync(change);
        }

        // 刪除異動紀錄
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // 依員工編號取得異動歷史
        public async Task<List<EmployeeChange>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _repository.GetByEmployeeIdAsync(employeeId);
        }
    }
}