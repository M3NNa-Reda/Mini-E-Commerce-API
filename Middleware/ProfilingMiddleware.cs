namespace Mini_E_Commerce_API.Middleware
{
    public class ProfilingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ProfilingMiddleware> _logger;

        public ProfilingMiddleware(RequestDelegate next,ILogger<ProfilingMiddleware> logger)
        {
            _next=next;
            _logger=logger;
        }
        public async Task Invoke(HttpContext context)
        {
            var startTime = DateTime.Now;
            var method = context.Request.Method;
            var path = context.Request.Path;
            _logger.LogInformation($"[{startTime:yyyy-MM-dd HH:mm:ss}] {method} {path}");
            await _next(context);
        }
    }
}
