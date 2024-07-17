using ECommerce.Ploto.Common.AuthenticationAbstraction.TokenBaseAuthenticationImplementation;
using ECommerce.Ploto.Common.CacheAbstraction;

namespace ECommerce.Ploto.WebAPI.Middlewares
{
    public class JWTAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        public JWTAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var authService = context.RequestServices.GetRequiredService<ITokenBaseAuthenticationService>();
            var cacheServoce = context.RequestServices.GetRequiredService<ICacheService>();

            var authorizationHeader = context.Request.Headers["Authorization"].ToString();
            if(string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer ") )
            {
                throw new Exception();
            }

            var claimsPrincple  = authService.ValidateJwtToken(authorizationHeader);

            
            
        }

    }
}
