using HeavenlyHR.Data;
using HeavenlyHR.Models;
using Microsoft.EntityFrameworkCore;

namespace HeavenlyHR.Repositories
{
    public class CandidateRepository
    {
        private readonly AppDbContext _context;

        public CandidateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Candidate>> GetAllAsync() =>
            await _context.Candidates.ToListAsync();

        public async Task<Candidate?> GetByIdAsync(int id) =>
            await _context.Candidates.FindAsync(id);

        public async Task AddAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
                await _context.SaveChangesAsync();
            }
        }
    }
}