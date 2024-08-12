using ECommerce.Ploto.WebAPI.Pollies;
using Polly;

namespace ECommerce.Ploto.WebAPI.Middlewares
{
    public class ResilienceMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IAsyncPolicy _resiliencePolicy;

        public ResilienceMiddleware(RequestDelegate next)
        {
            _next = next;
            _resiliencePolicy = CombinedResiliencePolicy.CreateCombinedPolicy();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _resiliencePolicy.ExecuteAsync(async () =>
            {
                await _next(context);
            });
        }
    }
}
