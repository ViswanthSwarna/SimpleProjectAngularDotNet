using CandidateTracker.Repository.Classes;
using CandidateTracker.Repository.Interfaces;
using CandidateTracker.Service.Classes;
using CandidateTracker.Service.Interfaces;

namespace CandidateTracker.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IResumeService, ResumeService>();
            return services;
        }
    }
}
