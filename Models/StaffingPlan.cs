using System;

namespace HeavenlyHR.Models
{
    public class StaffingPlan
    {
        public int Id { get; set; }  // 作為主鍵
        public int Year { get; set; } //年度

        public string? DepartmentName { get; set; }  // 部門名稱(關聯)
        public string? JobTitle { get; set; }        // 職稱(關聯)
        public int? PlannedHeadcount { get; set; }   // 編制人數

        public DateTime? EffectiveDate { get; set; } = DateTime.Now;  // 生效日期
        public string? CreatedBy { get; set; }        // 建立人
        public DateTime? CreatedAt { get; set; } = DateTime.Now; // 建立時間
    }
}