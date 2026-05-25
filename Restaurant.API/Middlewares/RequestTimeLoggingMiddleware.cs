using System.Diagnostics;

namespace Restaurant.API.Middlewares;

public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> _logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopwatch = Stopwatch.StartNew();
        await next.Invoke(context);
        stopwatch.Stop();

        if(stopwatch.ElapsedMilliseconds /1000 > 4)
        {
            _logger.LogInformation("Request [{Verb}] at {path} took {Time} ms",
                context.Request.Method,
                context.Request.Path,
                stopwatch.ElapsedMilliseconds);
        }

    }
}
