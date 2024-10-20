using Microsoft.EntityFrameworkCore;

namespace JobCandidate.Data.Repository.Base.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        DbSet<T> Table();
    }
}
