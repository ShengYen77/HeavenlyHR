using HeavenlyHR.Models;
using Microsoft.EntityFrameworkCore;

namespace HeavenlyHR.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; } // 對應到資料表
    }
}