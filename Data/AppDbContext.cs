using HeavenlyHR.Models;
using Microsoft.EntityFrameworkCore;

namespace HeavenlyHR.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; } // 員工資料表

        public DbSet<EmployeeChange> EmployeeChanges { get; set; } // 員工異動資料表
        
        public DbSet<Candidate> Candidates { get; set; }  //候選人資料表
        
        public DbSet<StaffingPlan> StaffingPlans { get; set; } //編制資料表


    }
}