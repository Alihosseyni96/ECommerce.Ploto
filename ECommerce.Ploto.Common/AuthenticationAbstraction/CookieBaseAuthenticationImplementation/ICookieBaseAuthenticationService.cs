using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.AuthenticationAbstraction.CookieBaseAuthenticationImpelimentation
{
    public interface ICookieBaseAuthenticationService
    {
        /// <summary>
        /// when ever you find out this user is valid to be login - call login service
        /// </summary>
        /// <param name="addClaims"></param>
        /// <returns></returns>
        Task<bool> LoginAsync(params (string claimKey, string value)[] addClaims);
        Task LogoutAsync();
        bool? IsAuthenticatedAsync();
        ClaimsPrincipal GetCurrentUserClaimsAsync();
    }
}
