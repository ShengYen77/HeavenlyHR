using HeavenlyHR.Data;
using HeavenlyHR.Models;
using Microsoft.EntityFrameworkCore;

namespace HeavenlyHR.Repositories
{
    public class StaffingPlanRepository
    {
        private readonly AppDbContext _context;

        public StaffingPlanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StaffingPlan>> GetAllAsync()
        {
            return await _context.StaffingPlans.ToListAsync();
        }

        public async Task<StaffingPlan> GetByIdAsync(int id)
        {
            return await _context.StaffingPlans.FindAsync(id);
        }

        public async Task AddAsync(StaffingPlan plan)
        {
            _context.StaffingPlans.Add(plan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StaffingPlan plan)
        {
            _context.StaffingPlans.Update(plan);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var plan = await _context.StaffingPlans.FindAsync(id);
            if (plan != null)
            {
                _context.StaffingPlans.Remove(plan);
                await _context.SaveChangesAsync();
            }
        }
    }
}