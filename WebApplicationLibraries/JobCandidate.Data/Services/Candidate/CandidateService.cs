using JobCandidate.Data.Entities;
using JobCandidate.Data.Repository.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobCandidate.Data.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IRepository<Candidate> _candidateRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICandidateServiceRule _candidateServiceRule;

        public CandidateService(
            IRepository<Candidate> candidateRepository,
            IUnitOfWork unitOfWork,
            ICandidateServiceRule candidateServiceRule)
        {
            _candidateRepository = candidateRepository;
            _unitOfWork = unitOfWork;
            _candidateServiceRule = candidateServiceRule;
        }

        public async Task AddAsync(Candidate candidate)
        {
            await _candidateServiceRule.SaveAsync(candidate);
            await _candidateRepository.AddAsync(candidate);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(Candidate candidate)
        {
            await _candidateServiceRule.SaveAsync(candidate);
            _candidateRepository.Update(candidate);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Candidate> GetCandidateByEmailAsync(string email)
        {
            return await _candidateRepository.Table().AsNoTracking().FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }
    }
}
