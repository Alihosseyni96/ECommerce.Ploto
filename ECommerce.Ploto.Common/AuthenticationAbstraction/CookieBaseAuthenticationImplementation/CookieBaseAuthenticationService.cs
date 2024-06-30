using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.AuthenticationAbstraction.CookieBaseAuthenticationImpelimentation
{
    public class CookieBaseAuthenticationService : ICookieBaseAuthenticationService
    {
        private readonly CookieAuthenticationProperties _options;
        private readonly HttpContext _httpContext;
        public CookieBaseAuthenticationService(CookieAuthenticationProperties options, HttpContext httpContext)
        {
            _options = options;
            _httpContext = httpContext;
        }
        public async Task<bool> LoginAsync(params (string claimKey, string value)[] addClaims)
        {
            var claims = new List<Claim>();
            foreach (var claim in addClaims)
            {
                claims.Add(new Claim(claim.claimKey, claim.value));
            }

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties()
            {
                IsPersistent = _options.IsPersistent,
                ExpiresUtc = _options.ExpiresUtc,
                IssuedUtc = _options.IssueDateUTC,
                RedirectUri = _options.RedirectUri,
                AllowRefresh = _options.AllowRefresh,
            };

            await _httpContext.SignInAsync(
                     CookieAuthenticationDefaults.AuthenticationScheme,
                     new ClaimsPrincipal(claimsIdentity),
                     authProperties);

            return true;
        }

        public async Task LogoutAsync()
        {
            await _httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }


        public ClaimsPrincipal GetCurrentUserClaimsAsync()
        {

            return _httpContext.User;
        }

        public bool? IsAuthenticatedAsync()
        {
            return _httpContext.User.Identity?.IsAuthenticated;
        }


    }
}
