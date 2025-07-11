namespace HeavenlyHR.Models;

public class ShiftSchedule
{
    public string EmployeeNumber { get; set; }   // 員工編號
    public DateTime Date { get; set; }           // 班別日期
    public TimeSpan StartTime { get; set; }      // 應上班時間
    public TimeSpan EndTime { get; set; }        // 應下班時間
}
