using HeavenlyHR.Models;
using HeavenlyHR.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeavenlyHR.Services
{
    public class CandidateService
    {
        private readonly CandidateRepository _repository;

        public CandidateService(CandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Candidate>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}