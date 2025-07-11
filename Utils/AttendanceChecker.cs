using HeavenlyHR.Models;

namespace HeavenlyHR.Utils
{
    public static class AttendanceChecker
    {
        private const int AllowedMinutesLate = 5;  // 遲到容許 5 分鐘
        private const int AllowedMinutesEarlyLeave = 5; // 早退容許 5 分鐘
        private const double MinimumWorkingHours = 8.0; // 最低工時

        public static bool CheckIsAbnormal(AttendanceRecord record, Dictionary<string, (TimeSpan start, TimeSpan end)> shiftTimes)
        {
            if (record.ShiftType == null || !shiftTimes.ContainsKey(record.ShiftType))
                return false;

            if (record.Clock_In_Time == null || record.Clock_Out_Time == null)
                return true; // 缺卡直接算異常

            var (standardIn, standardOut) = shiftTimes[record.ShiftType];

            DateTime expectedStart = record.Date.Date + standardIn;
            DateTime expectedEnd = record.Date.Date + standardOut;

            bool isLate = record.Clock_In_Time.Value > expectedStart.AddMinutes(AllowedMinutesLate);
            bool isEarlyLeave = record.Clock_Out_Time.Value < expectedEnd.AddMinutes(-AllowedMinutesEarlyLeave);

            double workHours = (record.Clock_Out_Time.Value - record.Clock_In_Time.Value).TotalHours;

            bool isShortHours = workHours < MinimumWorkingHours;

            return isLate || isEarlyLeave || isShortHours;
        }
    }
}