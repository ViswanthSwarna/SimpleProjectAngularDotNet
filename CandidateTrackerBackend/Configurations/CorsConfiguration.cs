namespace CandidateTracker.Api.Configurations
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services) {
            services.AddCors(options =>
            {
                options.AddPolicy("CORS", corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true));
            });
            return services;
        }
    }
}
