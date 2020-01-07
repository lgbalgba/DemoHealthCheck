using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DemoHealthCheck
{
    public class MockHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("https://localhost:44357/api/values");

            if (!result.IsSuccessStatusCode)
                return HealthCheckResult.Unhealthy(string.Empty);
            
            return HealthCheckResult.Healthy(string.Empty);
        }
    }
}
