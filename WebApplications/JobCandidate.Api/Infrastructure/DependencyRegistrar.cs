using FluentValidation;
using JobCandidate.Api.Models;
using JobCandidate.Data;
using JobCandidate.Data.Mapping;
using JobCandidate.Data.Repository.Base;
using JobCandidate.Data.Repository.Base.Interfaces;
using JobCandidate.Data.Services;
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

            #region Services
            services.AddScoped<ICandidateService, CandidateService>();
            #endregion

            #region ServiceRules
            services.AddScoped<ICandidateServiceRule, CandidateServiceRule>();
            #endregion

            #region Validators
            services.AddTransient<IValidator<CandidateModel>, CandidateValidator>();
            #endregion
        }
    }
}
