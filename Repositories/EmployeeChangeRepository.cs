using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HeavenlyHR.Data;
using HeavenlyHR.Models;

namespace HeavenlyHR.Repositories
{
    public class EmployeeChangeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeChangeRepository(AppDbContext context)
        {
            _context = context;
        }

        // 取得所有異動紀錄
        public async Task<List<EmployeeChange>> GetAllAsync()
        {
            return await _context.EmployeeChanges
                                 .Include(ec => ec.Employee)  // 載入關聯員工資料
                                 .ToListAsync();
        }

        // 根據 Id 取得單筆異動紀錄
        public async Task<EmployeeChange> GetByIdAsync(int id)
        {
            return await _context.EmployeeChanges
                                 .Include(ec => ec.Employee)
                                 .FirstOrDefaultAsync(ec => ec.Id == id);
        }

        // 新增異動紀錄
        public async Task AddAsync(EmployeeChange change)
        {
            await _context.EmployeeChanges.AddAsync(change);
            await _context.SaveChangesAsync();
        }

        // 更新異動紀錄
        public async Task UpdateAsync(EmployeeChange change)
        {
            _context.EmployeeChanges.Update(change);
            await _context.SaveChangesAsync();
        }

        // 刪除異動紀錄
        public async Task DeleteAsync(int id)
        {
            var change = await _context.EmployeeChanges.FindAsync(id);
            if (change != null)
            {
                _context.EmployeeChanges.Remove(change);
                await _context.SaveChangesAsync();
            }
        }

        // 可擴充：查詢特定員工所有異動紀錄
        public async Task<List<EmployeeChange>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _context.EmployeeChanges
                                 .Include(ec => ec.Employee)
                                 .Where(ec => ec.EmployeeId == employeeId)
                                 .ToListAsync();
        }
    }
}
