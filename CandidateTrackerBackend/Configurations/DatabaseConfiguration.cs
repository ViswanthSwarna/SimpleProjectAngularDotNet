using CandidateTracker.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CandidateTracker.Api.Configurations
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<CandidateTrackerContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("APIConnection"))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            return services;
        }
    }
}
