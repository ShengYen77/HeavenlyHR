namespace HeavenlyHR.Utils
{
    public static class ShiftScheduleProvider
    {
        public static Dictionary<string, (TimeSpan start, TimeSpan end)> GetShiftSchedules()
        {
            return new Dictionary<string, (TimeSpan, TimeSpan)>
            {
                { "A", (TimeSpan.Parse("08:00"), TimeSpan.Parse("17:00")) },
                { "B", (TimeSpan.Parse("08:30"), TimeSpan.Parse("17:30")) },
                { "C", (TimeSpan.Parse("09:00"), TimeSpan.Parse("18:00")) }
            };
        }
    }
}