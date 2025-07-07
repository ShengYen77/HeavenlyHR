using System.Text;
using HeavenlyHR.Models;

namespace HeavenlyHR.Export
{
    public static class CsvExporter
    {
        public static string ExportEmployeesToCsv(List<Employee> employees)
        {
            var sb = new StringBuilder();

            // 標題列
            sb.AppendLine("Id,FullName,HireDate,ReturnToWorkDate,LeaveDate,SeniorityStartDate,ProbationEndDate,DepartmentName,DirectSupervisor,EmployeeType,EmploymentType,JobTitle,JobPosition,IdNumber,BirthDate,Nationality,Gender,MaritalStatus,HealthStatus,EmergencyContactName,EmergencyContactPhone,MobilePhone,ContactPhone,MilitaryServiceStatus,MailingAddress,RegisteredAddress,CompanyEmail,PersonalEmail");

            // 每筆員工資料
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.Id},{e.FullName},{e.HireDate:yyyy-MM-dd},{e.ReturnToWorkDate:yyyy-MM-dd},{e.LeaveDate:yyyy-MM-dd},{e.SeniorityStartDate:yyyy-MM-dd},{e.ProbationEndDate:yyyy-MM-dd},{e.DepartmentName},{e.DirectSupervisor},{e.EmployeeType},{e.EmploymentType},{e.JobTitle},{e.JobPosition},{e.IdNumber},{e.BirthDate:yyyy-MM-dd},{e.Nationality},{e.Gender},{e.MaritalStatus},{e.HealthStatus},{e.EmergencyContactName},{e.EmergencyContactPhone},{e.MobilePhone},{e.ContactPhone},{e.MilitaryServiceStatus},{e.MailingAddress},{e.RegisteredAddress},{e.CompanyEmail},{e.PersonalEmail}");
            }

            return sb.ToString();
        }
    }
}