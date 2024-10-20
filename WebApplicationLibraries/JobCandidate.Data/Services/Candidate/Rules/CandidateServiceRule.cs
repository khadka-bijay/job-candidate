using JobCandidate.Data.Entities;
using JobCandidate.Data.Repository.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobCandidate.Data.Services
{
    public class CandidateServiceRule : ICandidateServiceRule
    {
        private readonly IRepository<Candidate> _candidateRepository;

        public CandidateServiceRule(IRepository<Candidate> candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task SaveAsync(Candidate candidate)
        {
            var candidates = await _candidateRepository.Table().AsNoTracking().Where(x => x.CandidateId != candidate.CandidateId && x.Email == candidate.Email).ToListAsync();
            if (candidates.Any())
            {
                throw new Exception("Email already in use.");
            }
        }
    }
}
