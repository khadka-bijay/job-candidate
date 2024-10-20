using JobCandidate.Data.Entities;

namespace JobCandidate.Data.Services
{
    public interface ICandidateServiceRule
    {
        Task SaveAsync(Candidate candidate);
    }
}
