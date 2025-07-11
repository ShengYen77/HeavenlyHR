using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HeavenlyHR.Data;
using HeavenlyHR.Models;

namespace HeavenlyHR.Repositories
{
    public class AttendanceRecordRepository : IAttendanceRecordRepository
    {
        private readonly AppDbContext _context;

        public AttendanceRecordRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AttendanceRecord>> GetAllAsync()
        {
            return await _context.AttendanceRecords.ToListAsync();
        }

        public async Task<AttendanceRecord> GetByIdAsync(int id)
        {
            return await _context.AttendanceRecords.FindAsync(id);
        }

        public async Task<List<AttendanceRecord>> GetByEmployeeIdAsync(string employeeId)
        {
            return await _context.AttendanceRecords
                .Where(a => a.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<List<AttendanceRecord>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.AttendanceRecords
                .Where(a => a.Date >= startDate && a.Date <= endDate)
                .ToListAsync();
        }

        public async Task AddAsync(AttendanceRecord record)
        {
            await _context.AttendanceRecords.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AttendanceRecord record)
        {
            _context.AttendanceRecords.Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var record = await _context.AttendanceRecords.FindAsync(id);
            if (record != null)
            {
                _context.AttendanceRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}
