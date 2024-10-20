using JobCandidate.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace JobCandidate.Data
{
    public class JobCandidateDbContext : DbContext
    {
        public JobCandidateDbContext(DbContextOptions<JobCandidateDbContext> options) : base (options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateMap());
        }
    }
}
