using HeavenlyHR.Models;
using HeavenlyHR.Repositories;

namespace HeavenlyHR.Services
{
    public class StaffingPlanService
    {
        private readonly StaffingPlanRepository _repository;

        public StaffingPlanService(StaffingPlanRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StaffingPlan>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<StaffingPlan> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(StaffingPlan plan)
        {
            await _repository.AddAsync(plan);
        }

        public async Task UpdateAsync(StaffingPlan plan)
        {
            await _repository.UpdateAsync(plan);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}