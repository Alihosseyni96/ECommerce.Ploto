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
            // Combined All Pollies to One , and in Execute of this one , i am calling entry of request to be applied for all requests
            await _resiliencePolicy.ExecuteAsync(async () =>
            {
                await _next(context);
            });
        }
    }
}
