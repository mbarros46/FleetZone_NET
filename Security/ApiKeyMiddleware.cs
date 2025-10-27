using System.Net;

namespace FleetZone_NET.Security
{
    public class ApiKeyMiddleware
    {
        private const string HeaderName = "X-API-KEY";
        private readonly RequestDelegate _next;
        private readonly string _configuredKey;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuredKey = configuration["Security:ApiKey"] ?? string.Empty;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLowerInvariant();
            if (path is not null && (path.StartsWith("/swagger") || path.StartsWith("/health")))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(HeaderName, out var providedKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Missing API Key.");
                return;
            }

            if (!string.Equals(providedKey.ToString(), _configuredKey, StringComparison.Ordinal))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Invalid API Key.");
                return;
            }

            await _next(context);
        }
    }
}
