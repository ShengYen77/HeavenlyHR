using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace HeavenlyHR.Models
{
    public enum ChangeType
    {
        離職,
        復職,
        內部異動
    }

    public enum ChangeMethod
    {
        自動,
        手動
    }

    public enum ChangeReason
    {
        調任,
        晉升,
        兼任,
        改敘,
        組織異動,
        資遣,
        去世,
        退休,
        離職
    }

    public class EmployeeChange
    {
        public int Id { get; set; }

        [Column("employee_id")]
        public int EmployeeId { get; set; }  // FK，關聯員工編號

        [Column("change_type")]
        public ChangeType ChangeType { get; set; }

        [Column("change_method")]
        public ChangeMethod ChangeMethod { get; set; }

        [Column("effective_date")]
        public DateTime EffectiveDate { get; set; }  // 生效日期

        [Column("approval_date")]
        public DateTime ApprovalDate { get; set; }   // 核准日期
        
        [Column("application_date")]
        public DateTime ApplicationDate { get; set; }  // 申請日期

        [Column("change_reason")]
        public ChangeReason ChangeReason { get; set; }

        [Column("remark")]
        public string? Remark { get; set; }  // 備註，可選填

        // 可選加入員工導覽屬性，方便 Entity Framework 關聯
        public Employee? Employee { get; set; }
    }
}