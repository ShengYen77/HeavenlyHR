using HeavenlyHR.Models;
using Microsoft.EntityFrameworkCore;

namespace HeavenlyHR.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; } // 員工資料表

        public DbSet<EmployeeChange> EmployeeChanges { get; set; } // 員工異動資料表

        public DbSet<Candidate> Candidates { get; set; } //候選人資料表

        public DbSet<StaffingPlan> StaffingPlans { get; set; } //編制資料表

        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }

        public DbSet<LaborInsuranceGrade> LaborInsuranceGrades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // 保留原本EF的行為

            modelBuilder.Entity<LaborInsuranceGrade>()
                .HasKey(l => l.Level); // 定義主鍵 Level

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.LaborInsuranceGrade)
                .WithMany() // 如果不需要反向導覽屬性，可以用WithMany() 空的
                .HasForeignKey(e => e.LaborInsuranceGradeId)
                .OnDelete(DeleteBehavior.Restrict); // 避免刪除行為 cascade delete
        }
    }
}
