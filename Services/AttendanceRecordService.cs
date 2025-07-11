using HeavenlyHR.Models;
using HeavenlyHR.Repositories;
using HeavenlyHR.Utils;

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
            //新增前判斷是否異常
            var shiftSchedules = ShiftScheduleProvider.GetShiftSchedules();
            record.IsAbnormal = AttendanceChecker.CheckIsAbnormal(record, shiftSchedules);
            await _repository.AddAsync(record);
        }

        public async Task UpdateAsync(AttendanceRecord record)
        {
            // 更新前判斷是否異常
            var shiftSchedules = ShiftScheduleProvider.GetShiftSchedules();
            record.IsAbnormal = AttendanceChecker.CheckIsAbnormal(record, shiftSchedules);
            await _repository.UpdateAsync(record);

        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}