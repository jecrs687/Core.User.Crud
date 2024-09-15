using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Core.User.Crud.Api.Extensions
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services)
        {
            services
                .AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy());
            return services;
        }

        public static void ConfigureHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks(new PathString("/hc"), new HealthCheckOptions
            {
                Predicate = check => check.Tags.Contains("ready"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            });
            app.UseHealthChecks(new PathString("/liveness"), new HealthCheckOptions
            {
                Predicate = registration => registration.Name.Contains("self"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

        }
    }
}