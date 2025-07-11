namespace HeavenlyHR.Models;

public class Employee
{
    public int Id { get; set; }  // 員工編號（主鍵）

    public string FullName { get; set; }  // 員工姓名

    public DateTime HireDate { get; set; }  // 到職日期（必填）

    public DateTime? ReturnToWorkDate { get; set; }  // 復職日期（可空）

    public DateTime? LeaveDate { get; set; }  // 離職日期（可空）

    public DateTime SeniorityStartDate { get; set; }  // 年資起算日期

    public DateTime ProbationEndDate { get; set; }  // 試用期滿日期

    public string DepartmentName { get; set; }  // 單位名稱

    public string DirectSupervisor { get; set; }  // 直屬主管

    public string EmployeeType { get; set; }  // 員工別

    public string EmploymentType { get; set; }  // 雇用型態

    public string JobTitle { get; set; }  // 職稱

    public string JobPosition { get; set; }  // 職務

    public string IdNumber { get; set; }  // 身分證字號

    public DateTime BirthDate { get; set; }  // 出生日期

    public string Nationality { get; set; }  // 國籍名稱

    public string Gender { get; set; }  // 性別

    public string MaritalStatus { get; set; }  // 婚姻狀況

    public string HealthStatus { get; set; }  // 健康狀況

    public string EmergencyContactName { get; set; }  // 緊急聯絡人

    public string EmergencyContactPhone { get; set; }  // 緊急聯絡人手機號碼

    public string MobilePhone { get; set; }  // 員工手機號碼

    public string ContactPhone { get; set; }  // 連絡電話

    public string MilitaryServiceStatus { get; set; }  // 服役名稱

    public string MailingAddress { get; set; }  // 通訊地址

    public string RegisteredAddress { get; set; }  // 戶籍地址

    public string CompanyEmail { get; set; }  // 電子郵件(公司)

    public string PersonalEmail { get; set; }  // 電子郵件(個人)
    
    public int? CandidateId { get; set; }  // Nullable，因不是每個員工都來自人才庫
    public Candidate Candidate { get; set; } 
    
    public int? LaborInsuranceGradeId { get; set; } // 對應 LaborInsuranceGrade.Level
    public LaborInsuranceGrade LaborInsuranceGrade { get; set; }

    public decimal? InsuredSalary { get; set; }           // 投保薪資
    public decimal? EmployeeContribution { get; set; }    // 員工自付額
    public decimal? EmployerContribution { get; set; }    // 雇主負擔額
    public decimal? GovernmentContribution { get; set; }  // 政府負擔額
}