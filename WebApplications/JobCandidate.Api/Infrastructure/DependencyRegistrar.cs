using JobCandidate.Data;
using JobCandidate.Data.Repository.Base;
using JobCandidate.Data.Repository.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobCandidate.Api.Infrastructure
{
    public static class DependencyRegistrar
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JobCandidateDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
