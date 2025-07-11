namespace HeavenlyHR.Models;

public class AttendanceRecord
{
    public int Id { get; set; }

    // 關聯到員工主檔（以員工編號為主鍵關聯）
    public string? EmployeeId { get; set; }
    public string? DepartmentName { get; set; }
    public string? FullName { get; set; }

    // 出勤日期
    public DateTime Date { get; set; }

    // 班別與時間
    public string? ShiftType { get; set; } // 例如：A班、B班、C班
    public string? ShiftTime { get; set; } // 例如：08:30-17:30（可作為顯示用）

    // 打卡時間
    public DateTime? Clock_In_Time { get; set; }
    public DateTime? Clock_Out_Time { get; set; }

    // 異常欄位（若出勤時數 < 8hr 可標記 "異常"）
    public bool? IsAbnormal { get; set; }

    // 擴充欄位（供後續串接請假、加班與補登流程）
    public string? LeaveType { get; set; }          // 若有請假則標記假別，例如 "病假"
    public double? OvertimeHours { get; set; }     // 實際加班時數
    public double? ScheduledOvertime { get; set; } // 預定加班時數
    public bool? HasSupplementForm { get; set; }    // 是否有補登單（忘記刷卡）
}
