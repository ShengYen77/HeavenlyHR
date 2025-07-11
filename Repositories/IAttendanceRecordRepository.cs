using HeavenlyHR.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeavenlyHR.Repositories
{
    public interface IAttendanceRecordRepository
    {
        Task<List<AttendanceRecord>> GetAllAsync();
        Task<AttendanceRecord> GetByIdAsync(int id);
        Task<List<AttendanceRecord>> GetByEmployeeIdAsync(string employeeId);
        Task<List<AttendanceRecord>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task AddAsync(AttendanceRecord record);
        Task UpdateAsync(AttendanceRecord record);
        Task DeleteAsync(int id);
    }
}