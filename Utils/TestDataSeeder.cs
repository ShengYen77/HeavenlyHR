using HeavenlyHR.Models;
using HeavenlyHR.Services;
using System;
using System.Threading.Tasks;

namespace HeavenlyHR.Utils
{
    public class TestDataSeeder
    {
        private readonly AttendanceRecordService _attendanceRecordService;

        public TestDataSeeder(AttendanceRecordService attendanceRecordService)
        {
            _attendanceRecordService = attendanceRecordService;
        }

        public async Task SeedAttendanceDataAsync()
        {
            var testRecord = new AttendanceRecord
            {
                EmployeeId = "E001",
                DepartmentName = "人資部",
                FullName = "王小明",
                Date = DateTime.Today,
                ShiftType = "A",
                ShiftTime = "08:00-17:00",
                Clock_In_Time = DateTime.Today.AddHours(8).AddMinutes(1),  // 08:01 上班
                Clock_Out_Time = DateTime.Today.AddHours(17).AddMinutes(15), // 17:15 下班
                LeaveType = null,
                OvertimeHours = 0,
                ScheduledOvertime = 0,
                HasSupplementForm = false
            };

            await _attendanceRecordService.AddAsync(testRecord);
        }
    }
}