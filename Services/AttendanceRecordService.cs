using HeavenlyHR.Models;
using HeavenlyHR.Repositories;

namespace HeavenlyHR.Services
{
    public class AttendanceRecordService
    {
        private readonly IAttendanceRecordRepository _repository;

        public AttendanceRecordService(IAttendanceRecordRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AttendanceRecord>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AttendanceRecord?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<AttendanceRecord>> GetByEmployeeIdAsync(string employeeId)
        {
            return await _repository.GetByEmployeeIdAsync(employeeId);
        }

        public async Task<IEnumerable<AttendanceRecord>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _repository.GetByDateRangeAsync(startDate, endDate);
        }

        public async Task AddAsync(AttendanceRecord record)
        {
            await _repository.AddAsync(record);
        }

        public async Task UpdateAsync(AttendanceRecord record)
        {
            await _repository.UpdateAsync(record);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}