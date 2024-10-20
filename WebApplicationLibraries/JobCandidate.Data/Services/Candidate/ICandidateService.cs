using JobCandidate.Data.Entities;

namespace JobCandidate.Data.Services
{
    public interface ICandidateService
    {
        Task AddAsync(Candidate candidate);
        Task UpdateAsync(Candidate candidate);
        Task<Candidate> GetCandidateByEmailAsync(string email);
    }
}
