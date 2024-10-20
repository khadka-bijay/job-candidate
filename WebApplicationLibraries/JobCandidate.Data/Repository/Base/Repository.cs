using JobCandidate.Data.Repository.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobCandidate.Data.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly JobCandidateDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(JobCandidateDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public DbSet<T> Table()
        {
            return _dbSet;
        }
    }
}
