namespace HeavenlyHR.Models
{
    public class Candidate
    {
        public int Id { get; set; }  // 候選人編號（作為主鍵）
        public string FullName { get; set; }  // 姓名
        public string? Gender { get; set; }  // 性別
        public DateTime? BirthDate { get; set; }  // 出生日期
        public string? Email { get; set; }  // 電子信箱
        public string? Phone { get; set; }  // 聯絡電話
        public string? Education { get; set; }  // 學歷
        public string? Experience { get; set; }  // 經歷
        public string? Skills { get; set; }  // 技能
        public string? ResumePath { get; set; }  // 履歷檔案路徑
        public DateTime CreatedAt { get; set; } = DateTime.Now;  // 建立時間
        public string? AppliedPosition { get; set; }
        public string? Status { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}