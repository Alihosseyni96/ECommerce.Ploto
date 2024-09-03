using StackExchange.Profiling;

namespace ECommerce.Ploto.WebAPI.Middlewares
{
    public class CustomProfilerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomProfilerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (MiniProfiler.Current.Step("Request"))
            {
                // Optionally, track custom operations here
                await _next(context);
            }
        }
    }
}
