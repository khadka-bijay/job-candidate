using JobCandidate.Data.Repository.Base.Interfaces;

namespace JobCandidate.Data.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JobCandidateDbContext _context;

        public UnitOfWork(JobCandidateDbContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
